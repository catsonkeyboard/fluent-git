using FluentGit.Pages.MainContent;
using FluentGit.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluentGit
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : IWindow
    {
        public MainWindowViewModel ViewModel { get; }

        public MainWindowView(MainWindowViewModel viewModel, INavigationService navigationService,
            IServiceProvider serviceProvider, ISnackbarService snackbarService,
            IDialogService dialogService)
        {
            Wpf.Ui.Appearance.Watcher.Watch(this);

            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            //snackbarService.SetSnackbarControl(RootSnackbar);
            //dialogService.SetDialogControl(RootDialog);
            //navigationService.SetNavigationControl(NavigationView);

            //NavigationView.SetServiceProvider(serviceProvider);
            //NavigationView.Loaded += (_, _) => NavigationView.Navigate(typeof(MainContentView));
        }

        //private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
        //{
        //    if (sender is not Wpf.Ui.Controls.Navigation.NavigationView navigationView)
        //        return;

        //    NavigationView.HeaderVisibility = navigationView.SelectedItem?.TargetPageType != typeof(MainContentView)
        //        ? Visibility.Visible
        //        : Visibility.Collapsed; 
        //}
    }
}
