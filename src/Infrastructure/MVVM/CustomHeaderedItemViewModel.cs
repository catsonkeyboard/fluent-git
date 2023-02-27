using CommunityToolkit.Mvvm.Messaging;
using Dragablz;
using FluentGit.Infrastructure.Message;
using FluentGit.Infrastructure.ViewBase;
using FluentGit.Pages.RepositoryInit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Infrastructure.MVVM
{
    public class CustomHeaderedItemViewModel : HeaderedItemViewModel
    {
        public String Key { get; set; }

        public CustomHeaderedItemViewModel() 
        {
            //WeakReferenceMessenger.Default.Register<CloneCompleteMessage>(this, (r, m) =>
            //{
            //    if(m.Value is BaseViewModel viewModel)
            //    {
            //        Content = viewModel.View;
            //    }
            //});
        }

        [ActivatorUtilitiesConstructor]
        public CustomHeaderedItemViewModel(String header, object content)
        {
            Header = header;
            Content = content;
            if(Content is RepositoryInitView repositoryInitView)
            {
                (repositoryInitView.ViewModel as RepositoryInitViewModel).CloneCompleteEvent += RepositoryInitViewModel_CloneCompleteEvent;
            }
        }

        private void RepositoryInitViewModel_CloneCompleteEvent(object? sender, BaseViewModel e)
        {
            Content = e.View;
        }
    }
}
