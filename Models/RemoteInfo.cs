using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluentGit.Models
{
    public class RemoteInfo : TreeItemInfo
    {
        public List<BranchInfo> Branches { get; set; }
    }
}
