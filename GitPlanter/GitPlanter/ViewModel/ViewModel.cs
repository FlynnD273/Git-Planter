using GitPlanter.View;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using GitPlanter.Command;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace GitPlanter.ViewModel
{
    internal class ViewModel : NotifyPropertyChangedBase
    {
        private string _commitMessage;
        public string CommitMessage
        {
            get { return _commitMessage; }
            set { _UpdateField(ref _commitMessage, value); }
        }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand CommitCommand { get; set; }
        public DelegateCommand RefreshChangesCommand { get; set; }

        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set { _UpdateField(ref _tabIndex, value); }
        }

        private ObservableCollection<CommitNode> _commits;
        public ObservableCollection<CommitNode> Commits
        {
            get { return _commits; }
            set { _UpdateField(ref _commits, value); }
        }

        private ObservableCollection<GitChange> _unstagedChanges;
        public ObservableCollection<GitChange> UnstagedChanges
        {
            get { return _unstagedChanges; }
            set { _UpdateField(ref _unstagedChanges, value); }
        }

        private ObservableCollection<GitChange> _stagedChanges;
        public ObservableCollection<GitChange> StagedChanges
        {
            get { return _stagedChanges; }
            set { _UpdateField(ref _stagedChanges, value); }
        }

        private const string repoPath = "DemoRepo";

        private readonly Repository repo = new Repository(Path.Combine(repoPath, ".git"));
        private readonly Signature user;
        private RepositoryStatus status;
        public ViewModel()
        {
            user = repo.Config.BuildSignature(DateTimeOffset.Now);
            Commits = new();
            UnstagedChanges = new();
            StagedChanges = new();
            Commits.CollectionChanged += Commits_CollectionChanged;
            RefreshCommand = new(Init);
            RefreshChangesCommand = new(InitChanges);
            CommitCommand = new(CommitChanges);
            InitChanges();
        }

        private void InitChanges()
        {
            UnstagedChanges.Clear();
            StagedChanges.Clear();

            status = repo.RetrieveStatus();

            foreach (var entry in status.Modified)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Modified));
            }
            foreach (var entry in status.Added)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Added));
            }
            foreach (var entry in status.Untracked)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Added));
            }
            foreach (var entry in status.Missing)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Removed));
            }
            foreach (var entry in status.Removed)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Removed));
            }
            foreach (var entry in status.RenamedInIndex)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Renamed));
            }
            foreach (var entry in status.RenamedInWorkDir)
            {
                UnstagedChanges.Add(new(entry, ChangeStatus.Renamed));
            }
            foreach (var entry in status.Staged)
            {
                ChangeStatus status = ChangeStatus.Added;
                switch (entry.State)
                {
                    case FileStatus.DeletedFromIndex:
                    case FileStatus.DeletedFromWorkdir:
                        status = ChangeStatus.Removed;
                        break;
                    case FileStatus.NewInIndex:
                    case FileStatus.NewInWorkdir:
                        status = ChangeStatus.Added;
                        break;
                    case FileStatus.ModifiedInIndex:
                    case FileStatus.ModifiedInWorkdir:
                        status = ChangeStatus.Modified;
                        break;
                }
                StagedChanges.Add(new(entry, status));
            }
        }

        public void StageChange(GitChange change)
        {
            UnstagedChanges.Remove(change);
            StagedChanges.Add(change);
            switch (change.ChangeStatus)
            {
                case ChangeStatus.Added:
                case ChangeStatus.Renamed:
                case ChangeStatus.Modified:
                    repo.Index.Add(change.Entry.FilePath);
                    break;
                case ChangeStatus.Removed:
                    repo.Index.Remove(change.Entry.FilePath);
                    break;
            }

            repo.Index.Write();
        }

        public void UnstageChange(GitChange change)
        {
            UnstagedChanges.Add(change);
            StagedChanges.Remove(change);
            repo.Index.Remove(change.Entry.FilePath);
            repo.Index.Write();
        }

        private void CommitChanges()
        {
            if (string.IsNullOrEmpty(CommitMessage))
            {
                MessageBox.Show("Commit message must not be empty!");
                return;
            }
            if (StagedChanges.Count == 0)
            {
                MessageBox.Show("No committed changes!");
                return;
            }
            Signature sig = new(user.Name, user.Email, DateTimeOffset.Now);
            repo.Commit(CommitMessage, sig, sig);
            Init();
            InitChanges();
            CommitMessage = "";
            TabIndex = 0;
        }

        private void Commits_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var obj in e.NewItems)
                    {
                        CommitNode commit = obj as CommitNode;
                        commit.PullEvent += PullCommits;
                        commit.PushEvent += PushCommits;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var obj in e.OldItems)
                    {
                        CommitNode commit = obj as CommitNode;
                        commit.PullEvent -= PullCommits;
                        commit.PushEvent -= PushCommits;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                case NotifyCollectionChangedAction.Replace:
                    if (e.NewItems != null)
                    {
                        foreach (var obj in e.NewItems)
                        {
                            CommitNode commit = obj as CommitNode;
                            commit.PullEvent += PullCommits;
                            commit.PushEvent += PushCommits;
                        }
                    }
                    if (e.OldItems != null)
                    {
                        foreach (var obj in e.OldItems)
                        {
                            CommitNode commit = obj as CommitNode;
                            commit.PullEvent -= PullCommits;
                            commit.PushEvent -= PushCommits;
                        }
                    }
                    break;
            }
        }

        private void Init()
        {
            Commits.Clear();

            var remoteBranch = repo.Head.TrackedBranch.CanonicalName;
            var branchName = repo.Head.FriendlyName;
            FetchOptions options = new FetchOptions();
            Commands.Fetch(repo, "origin", new string[] { $"refs/heads/{branchName}:refs/remotes/origin/{branchName}" }, null, null);

            var localCommits = repo.Head.Commits.Reverse();
            var remoteCommits = repo.Branches[remoteBranch].Commits.Reverse();

            foreach (var commit in localCommits)
            {
                CommitNode newCommit = new(commit);
                newCommit.Status = NodeStatus.Local;
                Commits.Add(newCommit);
            }

            foreach (var commit in remoteCommits)
            {
                var dupCommit = Commits.FirstOrDefault(x => x.Commit.Id == commit.Id);
                if (dupCommit == null)
                {
                    CommitNode newCommit = new(commit);
                    newCommit.Status = NodeStatus.Remote;
                    Commits.Add(newCommit);
                }
                else
                {
                    dupCommit.Status = NodeStatus.Both;
                }
            }

            for (int i = 1; i < Commits.Count; i++)
            {
                if (Commits[i].Status != NodeStatus.Both)
                {
                    Commits[i - 1].Status = NodeStatus.LocalHead;
                }
            }

            for (int i = 0; i < Commits.Count; i++)
            {
                var commit = Commits[i];
                commit.Width = 15 - ((double)i / (Commits.Count - 1)) * 5;
                commit.X = 0.5 + ((i % 2) * 2 - 1) * (0.05 * (1 - (double)i / (Commits.Count - 1)));
                commit.Y = 0.9 - ((double)i / (Commits.Count - 1)) * 0.8;
                if (i == 0)
                {
                    commit.X2 = 0.5;
                    commit.Y2 = 1;
                    commit.X = 0.5;
                }
                else
                {
                    commit.X2 = Commits[i - 1].X;
                    commit.Y2 = Commits[i - 1].Y;
                }
            }
        }

        private void PullCommits(object sender, Commit commit)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = repoPath,
                FileName = "git",
                Arguments = "pull origin " + commit.Sha,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            CommandDialog dialog = new(processStartInfo);
            dialog.ShowDialog();
            Init();
        }

        private void PushCommits(object sender, Commit commit)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = repoPath,
                FileName = "git",
                Arguments = "push",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            CommandDialog dialog = new(processStartInfo);
            dialog.ShowDialog();

            Init();
        }

        public void SizeChanged()
        {
            if (Commits == null || Commits.Count == 0) { return; }
            foreach (var commit in Commits)
            {
                commit.SizeChanged();
            }
        }
    }
}
