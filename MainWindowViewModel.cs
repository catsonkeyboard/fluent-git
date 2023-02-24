using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Dragablz;
using FluentGit.Infrastructure.MVVM;
using FluentGit.Pages.RepositoryContent;
using FluentGit.Pages.RepositoryInit;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    
    [ObservableProperty]
    private string _applicationTitle;

    public IInterTabClient InterTabClient => new InterTabClient();

    [ObservableProperty]
    private ObservableCollection<HeaderedItemViewModel> _items = new ObservableCollection<HeaderedItemViewModel>();

    public Func<HeaderedItemViewModel> Factory
    {
        get
        {
            return
                () =>
                {
                    var dateTime = DateTime.Now;
                    var contentViewModel = _serviceProvider.GetService<RepositoryInitViewModel>();
                    return new CustomHeaderedItemViewModel()
                    {
                        Header = "New Repository",
                        Content = contentViewModel.View,
                    };
                };
        }
    }

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _applicationTitle = "FluentGit";
        Items.Add(Factory());
    }
    
    private void OnToggleThemeClicked(object sender, RoutedEventArgs e)
    {
        var currentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();

        Wpf.Ui.Appearance.Theme.Apply(currentTheme == Wpf.Ui.Appearance.ThemeType.Light ? Wpf.Ui.Appearance.ThemeType.Dark : Wpf.Ui.Appearance.ThemeType.Light);
    }
    
}