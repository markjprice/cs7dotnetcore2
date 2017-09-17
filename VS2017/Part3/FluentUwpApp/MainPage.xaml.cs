using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FluentUwpApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            clickMeButton.Content = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Button b in gridCalculator.Children.OfType<Button>())
            {
                b.FontSize = 24;
                b.Width = 54;
                b.Height = 54;
                b.Style = Resources.ThemeDictionaries["ButtonRevealStyle"] as Style;
            }
        }

        /*
        private void enableFluentDesign_Checked(object sender, RoutedEventArgs e)
        {
            if (enableFluentDesign.IsChecked.HasValue && enableFluentDesign.IsChecked.Value)
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
                {
                    var myBrush = new AcrylicBrush();
                    myBrush.BackgroundSource = AcrylicBackgroundSource.HostBackdrop;
                    myBrush.TintColor = Color.FromArgb(255, 202, 24, 37);
                    myBrush.FallbackColor = Color.FromArgb(255, 202, 24, 37);
                    myBrush.TintOpacity = 0.6;
                    toolbar.Background = myBrush;
                }
                else
                {
                    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));
                    toolbar.Background = myBrush;
                }
            }
            else
            {
                toolbar.Background = new SolidColorBrush(Colors.LightGray);
            }
        }
        */
    }
}
