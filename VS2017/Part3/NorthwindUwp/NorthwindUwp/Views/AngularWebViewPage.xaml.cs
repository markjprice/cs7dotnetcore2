using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class AngularWebViewPage : Page
    {
        public AngularWebViewViewModel ViewModel { get; } = new AngularWebViewViewModel();

        public AngularWebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
