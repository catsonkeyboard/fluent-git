using FluentGit.Infrastructure.MVVM;
using FluentGit.Models;
using FluentGit.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluentGit.Pages.RepositoryContent;

public partial class RepositoryContentViewModel : BaseViewModel
{
    [ObservableProperty]
    private ICollection<CommitInfo> _commitInfos;

    public RepositoryContentViewModel(RepositoryContentView view, GitService gitService) : base(view)
    {
        CommitInfos = new ObservableCollection<CommitInfo>
        {
            new()
            {
                Message = "bugfix:修复多次通知，修复集合中map匹配问题",
                Author = "张三",
                Branch = "main",
                DateTime = DateTime.Now
            },
            new()
            {
                Message = "bugfix:修复多次通知，修复集合中map匹配问题",
                Author = "李四",
                Branch = "main",
                DateTime = DateTime.Now
            },
            new CommitInfo
            {
                Message = "bugfix:修复多次通知，修复集合中map匹配问题",
                Author = "王五",
                Branch = "main",
                DateTime = DateTime.Now
            },
            new CommitInfo
            {
                Message = "bugfix:修复多次通知，修复集合中map匹配问题",
                Author = "张三",
                Branch = "main",
                DateTime = DateTime.Now
            }
        };
    }

}