using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NorthwindUwp.Views
{
    public sealed partial class CustomerMapPage : Page
    {
        public CustomerMapViewModel ViewModel { get; } = new CustomerMapViewModel();

        public CustomerMapPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
