using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Services
{
    public class GitRepositoryAsync
    {
        public Task<String> Clone(string sourceUrl, string workdirPath)
        {
            return Task<String>.Run(() =>
            {
                return Repository.Clone(sourceUrl, workdirPath);
            });
        }
    }
}
