using GitPlanter.ViewModel;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPlanter.View
{
    internal enum NodeStatus
    {
        Remote,
        Local,
        Both,
    }
    internal class CommitNode : NotifyPropertyChangedBase
    {
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

        private CommitNode _next;
        public CommitNode Next
        {
            get { return _next; }
            set { _UpdateField(ref _next, value); }
        }

        public CommitNode(Commit commit)
        {
            Commit = commit;
        }
    }
}
