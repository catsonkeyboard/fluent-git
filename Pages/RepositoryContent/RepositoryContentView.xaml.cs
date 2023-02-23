using FluentGit.Infrastructure.ViewBase;
using System.Windows.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit.Pages.RepositoryContent;

public partial class RepositoryContentView : BaseView
{
    public RepositoryContentView(RepositoryContentViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }


}