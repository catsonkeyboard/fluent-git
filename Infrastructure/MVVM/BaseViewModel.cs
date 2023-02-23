using Dragablz;
using FluentGit.Infrastructure.ViewBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Infrastructure.MVVM
{
    public class BaseViewModel : ObservableObject
    {
        public IView? View { get; set; }
    }
}
