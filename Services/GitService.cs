using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Services
{
    public class GitService
    {

        public String GitClone(String path)
        {
            return Repository.Clone("https://github.com/libgit2/libgit2sharp.git", path);
        }

    }
}
