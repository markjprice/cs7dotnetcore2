using System;

using NorthwindUwp.Models;
using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NorthwindUwp.Views
{
    public sealed partial class CategoryMasterDetailDetailPage : Page
    {
        public CategoryMasterDetailDetailViewModel ViewModel { get; } = new CategoryMasterDetailDetailViewModel();

        public CategoryMasterDetailDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Item = e.Parameter as SampleOrder;
        }
    }
}
