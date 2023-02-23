using System.Windows.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit.Pages.RepositoryContent;

public partial class RepositoryContentView : INavigableView<RepositoryContentViewModel>
{
    public RepositoryContentViewModel ViewModel { get; }
    
    public RepositoryContentView(RepositoryContentViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }


}