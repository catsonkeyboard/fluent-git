using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluentGit.Models
{
    public class BranchInfo : TreeItemInfo
    {
        public String CanoicalName { get; set; }

        public bool IsRemote { get; set; }

        public String RemoteName { get; set; }

        public Branch Branch { get; set; }

        //public List<CommitInfo> CommitInfos { get; set; }

    }
}
