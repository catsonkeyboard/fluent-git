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
        private String _localPath;
        private String _remotePath;
        private Repository _repo;

        public String Path
        {
            get
            {
                return _repo.Info.Path;
            }
        }

        public GitService(String localPath)
        {
            _repo = new Repository(localPath);
        }
    }
}
