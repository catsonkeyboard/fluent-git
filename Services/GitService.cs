using FluentGit.Models;
using LibGit2Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentGit.Services
{
    public class GitService : IDisposable
    {
        private String _localPath;
        private String _remotePath;
        private Repository _repo;

        public String Name { get; private set; }

        [ActivatorUtilitiesConstructor]
        public GitService(String localPath)
        {
            _localPath = localPath;
            _repo = new Repository(localPath);
        }

        public ICollection<BranchInfo> GetLocalBranches()
        {
            return _repo.Branches.Where(p => !p.IsRemote).Select(p =>
            {
                return new BranchInfo
                {
                    Name = p.FriendlyName,
                    CanoicalName = p.CanonicalName,
                    FriendlyName = p.FriendlyName,
                    Branch = p
                };
            }
            ).ToList();
        }

        public ICollection<RemoteInfo> GetRemoteBranches()
        {
            List<RemoteInfo> remoteInfos = new();
            var remotes = _repo.Branches
                .Where(p => p.IsRemote)
                .Select(p => p.RemoteName)
                .Distinct()
                .Select(p => new BranchInfo { Name = p }
            ).ToList();
            foreach(var remote in remotes)
            {
                RemoteInfo remoteInfo = new RemoteInfo();
                remoteInfo.Name = remote.Name;
                remoteInfo.Branches = _repo.Branches.Where(p => p.IsRemote && p.RemoteName.Equals(remote.Name))
                    .Select(t => new BranchInfo 
                    { 
                        Name = t.FriendlyName, 
                        CanoicalName = t.CanonicalName,
                        FriendlyName = t.FriendlyName 
                    }
                    ).ToList();
                remoteInfos.Add(remoteInfo);
            }
            return remoteInfos;
        }

        public ICollection<CommitInfo> GetCommitInfos(Branch branch)
        {
            return branch.Commits.AsEnumerable<Commit>().ToList()
                            .Select(p => {
                                var i = 0;
                                var parents = p.Parents;
                                List<ChangeInfo> changes = new();
                                foreach (var parent in parents)
                                {
                                    foreach (TreeEntryChanges change in _repo.Diff.Compare<TreeChanges>(parent.Tree, p.Tree))
                                    {
                                        ChangeInfo changeInfo = new ChangeInfo
                                        {
                                            ChangeKind = change.Status,
                                            Path = change.Path,
                                        };
                                        changes.Add(changeInfo);
                                        i++;
                                    }
                                }
                                return new CommitInfo
                                {
                                    MessageShort = p.MessageShort,
                                    DateTime = p.Author.When.DateTime,
                                    Author = p.Author.Name,
                                    Count = i,
                                    Commit = p,
                                    ChangeInfos= changes
                                };
                            }).ToList();
        }

        public CommitDetailInfo GetCommitDetailInfo(CommitInfo commit)
        {
            return new CommitDetailInfo
            {
                Hash = commit.Commit.Sha,
                Tree = commit.Commit.Tree.Sha,
                Author = commit.Commit.Author.Name,
                Date = commit.Commit.Author.When.DateTime,
                Parent = commit.Commit.Parents.First()?.Sha,
                Message = commit.Commit.Message,
                ChangeInfos = commit.ChangeInfos
            };
        }

        public ICollection<TagInfo> GetTags()
        {
            return _repo.Tags.Select(p => new TagInfo
            {
                Name = p.CanonicalName
            }
            ).ToList();
        }

        public void Dispose()
        {

        }
    }
}
