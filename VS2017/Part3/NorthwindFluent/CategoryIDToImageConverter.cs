using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace NorthwindFluent
{
    public class CategoryIDToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int n = (int)value;
            string path = $"{Environment.CurrentDirectory}/Assets/category{n}-small.jpeg";
            var image = new BitmapImage(new Uri(path));
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
