using GitPlanter.ViewModel;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPlanter.View
{
    internal enum ChangeStatus
    {
        Modified,
        Added,
        Removed,
        Renamed,
    }
    internal class GitChange : NotifyPropertyChangedBase
    {
        private StatusEntry _entry;
        public StatusEntry Entry
        {
            get { return _entry; }
            set { _UpdateField(ref _entry, value); }
        }

        private ChangeStatus _changeStatus;
        public ChangeStatus ChangeStatus
        {
            get { return _changeStatus; }
            set { _UpdateField(ref _changeStatus, value); }
        }

        public GitChange(StatusEntry entry, ChangeStatus status)
        {
            Entry = entry;
            ChangeStatus = status;
        }
    }
}
