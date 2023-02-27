using FluentGit.Infrastructure.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Infrastructure.ViewBase
{
    public interface IView
    {
        BaseViewModel ViewModel { get; }
    }
}
