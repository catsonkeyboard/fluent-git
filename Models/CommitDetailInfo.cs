using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluentGit.Models
{
    public record CommitDetailInfo
    {
        public String Hash { get; set; }

        public String Tree { get; set; }

        public String Author { get; set; }

        public DateTime Date { get; set; }

        public String Parent { get; set; }

        public String[] BrancheNames { get; set; }

        public String Stats { get; set; }

        public String Message { get; set; }

        public List<ChangeInfo> ChangeInfos { get; set; }

    }
}
