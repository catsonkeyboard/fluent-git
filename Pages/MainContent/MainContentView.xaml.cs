using System.Windows.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit.Pages.MainContent;

public partial class MainContentView: INavigableView<MainContentViewModel>
{
    public MainContentViewModel ViewModel { get; }
    
    public MainContentView(MainContentViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }


}