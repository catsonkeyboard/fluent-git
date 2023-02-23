using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Pages.RepositoryInit
{
    public partial class RepositoryInitViewModel : ObservableObject
    {
        [RelayCommand]
        public void ChooseDirectory()
        {
            Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Dark);
            Console.WriteLine("aaa");
        }

        [RelayCommand]
        public void Clone()
        {

        }

    }
}
