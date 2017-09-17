using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class AboutNorthwindAppPage : Page
    {
        public AboutNorthwindAppViewModel ViewModel { get; } = new AboutNorthwindAppViewModel();

        public AboutNorthwindAppPage()
        {
            InitializeComponent();
        }
    }
}
