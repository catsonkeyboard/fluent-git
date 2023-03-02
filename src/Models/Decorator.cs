using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Models
{
    public enum DecoratorType
    {
        None,
        CurrentBranchHead,
        LocalBranchHead,
        RemoteBranchHead,
        Tag,
    }

    public class Decorator
    {
        public DecoratorType Type { get; set; }

        public String Name { get; set; }
    }
}
