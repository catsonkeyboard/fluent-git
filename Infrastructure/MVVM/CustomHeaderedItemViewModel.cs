using CommunityToolkit.Mvvm.Messaging;
using Dragablz;
using FluentGit.Infrastructure.Message;
using FluentGit.Infrastructure.ViewBase;
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
            WeakReferenceMessenger.Default.Register<CloneCompleteMessage>(this, (r, m) =>
            {
                if(m.Value is IView view)
                {
                    Content = view;
                }
            });
        }

    }
}
