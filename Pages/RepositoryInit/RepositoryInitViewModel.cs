using CommunityToolkit.Mvvm.Messaging;
using FluentGit.Infrastructure.Message;
using FluentGit.Infrastructure.MVVM;
using FluentGit.Pages.RepositoryContent;
using FluentGit.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System;

namespace FluentGit.Pages.RepositoryInit
{
    public partial class RepositoryInitViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private String? _newRepositoryUrl;

        [ObservableProperty]
        private String? _newRepositoryName;

        [ObservableProperty]
        private String? _newRepositoryPath;

        [ObservableProperty]
        private Boolean _progressBarVisible = false;

        public RepositoryInitViewModel(IServiceProvider serviceProvider,RepositoryInitView view) : base(view) 
        {
            _serviceProvider = serviceProvider;
        }


        [RelayCommand]
        public void ChooseDirectory()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var ok = dialog.ShowDialog();
            if (ok == System.Windows.Forms.DialogResult.OK)
            {
                NewRepositoryPath = dialog.SelectedPath;
            }
        }

        [RelayCommand]
        public void Clone()
        {
            //if (String.IsNullOrEmpty(NewRepositoryUrl)
            //    || String.IsNullOrEmpty(NewRepositoryName)
            //    || String.IsNullOrEmpty(NewRepositoryPath)) return;
            //ProgressBarVisible = true;
            //var repositoryAsync = _serviceProvider.GetService<RepositoryAsync>();
            //if (repositoryAsync != null)
            //{
            //    var cloneTask = repositoryAsync
            //        .Clone(NewRepositoryUrl, NewRepositoryPath + "\\" + NewRepositoryName);
            //    cloneTask
            //        .GetAwaiter()
            //        .OnCompleted(() =>
            //        {
            //            var gitService = new GitService(cloneTask.Result);
            //            var path2 = gitService.Path;
            //            ProgressBarVisible = false;
            //        });
            //}
            var viewModel = _serviceProvider.GetService<RepositoryContentViewModel>();
            if(viewModel != null)
            {
                WeakReferenceMessenger.Default.Send(new CloneCompleteMessage(viewModel));
            }
        }
    }
}
