using FluentGit.Infrastructure.MVVM;
using FluentGit.Models;
using FluentGit.Services;
using System.Collections.Generic;

namespace FluentGit.Pages.RepositoryContent;

public partial class RepositoryContentViewModel : BaseViewModel
{
    private GitService _gitService;

    [ObservableProperty]
    private ICollection<BranchInfo> _locals;

    [ObservableProperty]
    private ICollection<RemoteInfo> _remotes;

    [ObservableProperty]
    private ICollection<TagInfo> _tags;

    [ObservableProperty]
    private ICollection<StashInfo> _stashes;

    [ObservableProperty]
    private ICollection<SubModuleInfo> _subModules;

    [ObservableProperty]
    private ICollection<CommitInfo> _commitInfos;

    [ObservableProperty]
    private BranchInfo _currentBranchInfo;

    [ObservableProperty]
    private CommitDetailInfo _commitDetailInfo;

    private CommitInfo _selectedCommitInfo;

    public CommitInfo SelectedCommitInfo
    {
        get => _selectedCommitInfo;
        set
        {
            SetProperty(_selectedCommitInfo, value, (newValue) => { 
                if (newValue != null)
                {
                    CommitDetailInfo = _gitService.GetCommitDetailInfo(newValue.Commit);
                }
            });
        }
    }

    object _selectedItem;

    public object SelectedItem
    {
        get 
        { 
            return _selectedItem; 
        }

        set
        {
            SetProperty(_selectedItem, value, 
                //change tree item callback
                (newValue) => 
                {
                    if(newValue is BranchInfo)
                    {
                        CurrentBranchInfo = (BranchInfo)newValue;
                        CommitInfos = _gitService.GetCommitInfos(CurrentBranchInfo.Branch);
                    }
                    //CommitInfos = 
                }
            );
        }
    }

    public RepositoryContentViewModel(RepositoryContentView view, GitService gitService) : base(view)
    {
        _gitService = gitService;
        Locals = _gitService.GetLocalBranches();
        Remotes = _gitService.GetRemoteBranches();
    }

}