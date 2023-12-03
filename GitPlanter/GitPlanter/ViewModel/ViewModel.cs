using GitPlanter.View;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPlanter.ViewModel
{
    internal class ViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<CommitNode> _commits;
        public ObservableCollection<CommitNode> Commits
        {
            get { return _commits; }
            set { _UpdateField(ref _commits, value); }
        }

        private readonly Repository repo = new Repository("DemoRepo/.git");
        public ViewModel()
        {

        }

        public void Init()
        {
            Commits = new(repo.Commits.QueryBy(new CommitFilter()).Reverse().Select(x => new CommitNode(x)));
            for (int i = 0; i < Commits.Count; i++)
            {
                var commit = Commits[i];
                commit.X = 0.5;
                commit.Y = 0.9 - ((double)i / (Commits.Count - 1)) * 0.8;
                if (i == 0)
                {
                    commit.X2 = 0.5;
                    commit.Y2 = 1;
                }
                else
                {
                    commit.X2 = Commits[i - 1].X;
                    commit.Y2 = Commits[i - 1].Y;
                }
            }
        }
    }
}
