using FluentGit.Services;
using System;

namespace FluentGit.Pages.RepositoryInit
{
    public partial class RepositoryInitViewModel : ObservableObject
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

        public RepositoryInitViewModel(IServiceProvider serviceProvider) 
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
            if(!String.IsNullOrEmpty(NewRepositoryUrl)
                && !String.IsNullOrEmpty(NewRepositoryName) 
                && !String.IsNullOrEmpty(NewRepositoryPath))
            {
                ProgressBarVisible = true;
                var repositoryAsync = _serviceProvider.GetService<RepositoryAsync>();
                if(repositoryAsync != null)
                {
                    var cloneTask = repositoryAsync
                        .Clone(NewRepositoryUrl, NewRepositoryPath + "\\" + NewRepositoryName);
                    cloneTask
                        .GetAwaiter()
                        .OnCompleted(() =>
                        {
                            var gitService = new GitService(cloneTask.Result);
                            var path2 = gitService.Path;
                            ProgressBarVisible = false;
                        });
                }
            }
        }

    }
}
