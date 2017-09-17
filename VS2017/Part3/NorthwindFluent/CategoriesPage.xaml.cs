using Packt.CS7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NorthwindFluent
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoriesPage : Page
    {
        public CategoriesViewModel ViewModel { get; set; }

        public CategoriesPage()
        {
            this.InitializeComponent();
            ViewModel = new CategoriesViewModel();
        }

        private async void CategoriesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Category)
            {
                var category = e.ClickedItem as Category;

                var categoryDialog = new ContentDialog
                {
                    Title = category.CategoryName,
                    Content = category.Description,
                    CloseButtonText = "OK"
                };

                ContentDialogResult result = await categoryDialog.ShowAsync();
            }
        }
    }
}
