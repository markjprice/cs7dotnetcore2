using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NorthwindUwp.Views
{
    public sealed partial class CategoryMasterDetailPage : Page
    {
        public CategoryMasterDetailViewModel ViewModel { get; } = new CategoryMasterDetailViewModel();

        public CategoryMasterDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
    }
}
