using LibGit2Sharp;
using System;

namespace FluentGit.Services
{
    public class GitService : IDisposable
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

        [ActivatorUtilitiesConstructor]
        public GitService(String localPath)
        {
            _localPath = localPath;
            _repo = new Repository(localPath);
        }

        public void Dispose()
        {

        }
    }
}
