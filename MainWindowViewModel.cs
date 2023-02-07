using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using FluentGit.Pages.MainContent;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Navigation;

namespace FluentGit;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    
    [ObservableProperty]
    private string _applicationTitle;

    [ObservableProperty]
    private ICollection<object> _menuItems;

    [ObservableProperty]
    private ICollection<object> _footerMenuItems = new ObservableCollection<object>();

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _applicationTitle = "FluentGit";
        
        _menuItems = new ObservableCollection<object>
        {
            //new NavigationViewItem("航班动态", SymbolRegular.WindowApps24, typeof(MainContentView)),
            //new NavigationViewItemSeparator(),
            //new NavigationViewItem {Content = "基础信息管理", Icon = new SymbolIcon { Symbol = SymbolRegular.CheckboxChecked24  }, MenuItems = new ObservableCollection<object>
            //{
            //    new NavigationViewItem { Content = "航司信息管理", TargetPageType = typeof(AirlineView) },
            //    new NavigationViewItem { Content = "机场信息管理", TargetPageType = typeof(MainContentView) },
            //}},
        };

        var toggleThemeNavigationViewItem = new NavigationViewItem
        {
            Content = "Toggle theme",
            Icon = new SymbolIcon { Symbol = SymbolRegular.PaintBrush24 }
        };
        toggleThemeNavigationViewItem.Click += OnToggleThemeClicked;

        _footerMenuItems.Add(toggleThemeNavigationViewItem);
        _footerMenuItems.Add(new NavigationViewItem { Content = "Settings", Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 }, });
    }
    
    private void OnToggleThemeClicked(object sender, RoutedEventArgs e)
    {
        var currentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();

        Wpf.Ui.Appearance.Theme.Apply(currentTheme == Wpf.Ui.Appearance.ThemeType.Light ? Wpf.Ui.Appearance.ThemeType.Dark : Wpf.Ui.Appearance.ThemeType.Light);
    }
    
}