using Dragablz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FluentGit
{
    public class InterTabClient : IInterTabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            var view = App.GetService<MainWindowView>();
            var viewModel = App.GetService<MainWindowViewModel>();
            view.DataContext = viewModel;
            return new NewTabHost<Window>(view, view.TabablzControl);
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}
