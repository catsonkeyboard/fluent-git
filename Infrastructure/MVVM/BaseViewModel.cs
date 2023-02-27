using Dragablz;
using FluentGit.Infrastructure.ViewBase;
using FluentGit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FluentGit.Infrastructure.MVVM
{
    public class BaseViewModel : ObservableObject
    {
        public IView View { get; set; }

        public String Title { get; set; }

        public BaseViewModel(IView view)
        { 
            View = view;
            ((BaseView)View).DataContext = View;
            ((BaseView)View).ViewModel = this;
        }
    }
}
