using FluentGit.Infrastructure.MVVM;
using FluentGit.Pages.RepositoryContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit.Infrastructure.ViewBase
{
    public class BaseView : UserControl, IView, INavigableView<BaseViewModel>
    {
        public BaseViewModel ViewModel { get; }
        public BaseView(BaseViewModel viewModel) 
        {
            viewModel.View = this;
            ViewModel = viewModel;
            DataContext = this;
        }
    }
}
