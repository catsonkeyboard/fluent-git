using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Dragablz;
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
    private ObservableCollection<HeaderedItemViewModel> _items;

    public Func<HeaderedItemViewModel> Factory
    {
        get
        {
            return
                () =>
                {
                    var dateTime = DateTime.Now;
                    return new HeaderedItemViewModel()
                    {
                        Header = new HeaderWithCloseViewModel() {
                            Header = dateTime.ToLongTimeString()
                        },
                        Content = _serviceProvider.GetService<RepositoryInitView>()
                    };
                };
        }
    }

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _applicationTitle = "FluentGit";
        Items = new ObservableCollection<HeaderedItemViewModel>();
        Items.Add(new HeaderedItemViewModel 
        { 
            Header = "HOME", 
            Content = "There is a TabablzControl.ShowDefault close button, but this demo illustrates how you can have close buttons on and off per tab, in the same TabablzControl." });
        Items.Add(new HeaderedItemViewModel
        {
            //Header = new HeaderWithCloseViewModel { Header = "Closable" },
            //Content = "This tab is closeable."
            Header = "jdksaghdfsg",
            Content = "dfsdfs"
        });
    }
    
    private void OnToggleThemeClicked(object sender, RoutedEventArgs e)
    {
        var currentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();

        Wpf.Ui.Appearance.Theme.Apply(currentTheme == Wpf.Ui.Appearance.ThemeType.Light ? Wpf.Ui.Appearance.ThemeType.Dark : Wpf.Ui.Appearance.ThemeType.Light);
    }
    
}