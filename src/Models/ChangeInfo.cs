using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluentGit.Models
{
    public class ChangeInfo
    {
        public LibGit2Sharp.ChangeKind ChangeKind { get; set; }

        public String OldPath { get; set; }

        public String Path { get; set; }
    }
}
