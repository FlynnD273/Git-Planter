using GitPlanter.Command;
using GitPlanter.ViewModel;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GitPlanter.View
{
    internal enum NodeStatus
    {
        Remote,
        Local,
        Both,
        LocalHead,
    }
    internal class CommitNode : NotifyPropertyChangedBase
    {
        public event EventHandler<Commit> PushEvent;
        public event EventHandler<Commit> PullEvent;
        public DelegateCommand OnClickCommand { get; set; }

        private NodeStatus _status;
        public NodeStatus Status
        {
            get { return _status; }
            set { _UpdateField(ref _status, value); }
        }

        private Commit _commit;
        public Commit Commit
        {
            get { return _commit; }
            private set { _UpdateField(ref _commit, value); }
        }

        private double _x;
        public double X
        {
            get { return _x; }
            set { _UpdateField(ref _x, value); }
        }
        private double _y;
        public double Y
        {
            get { return _y; }
            set { _UpdateField(ref _y, value); }
        }

        private double _X2;
        public double X2
        {
            get { return _X2; }
            set { _UpdateField(ref _X2, value); }
        }

        private double _Y2;
        public double Y2
        {
            get { return _Y2; }
            set { _UpdateField(ref _Y2, value); }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set { _UpdateField(ref _width, value); }
        }

        private CommitNode _next;
        public CommitNode Next
        {
            get { return _next; }
            set { _UpdateField(ref _next, value); }
        }

        public CommitNode(Commit commit)
        {
            Commit = commit;
            OnClickCommand = new(_OnClick);
        }

        private void _OnClick()
        {
            if (Status == NodeStatus.Local)
            {
                PushEvent.Invoke(this, Commit);
            }
            else if (Status == NodeStatus.Remote)
            {
                PullEvent.Invoke(this, Commit);
            }
        }

        public void SizeChanged()
        {
            X = X;
            Y = Y;
            Width = Width;
            X2 = X2;
            Y2 = Y2;
        }
    }
}
