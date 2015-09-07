using Windows.UI.Xaml.Data;

namespace FormulaOnePerformance.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var imageName = value.ToString().Replace(" ", string.Empty);
                return string.Format("ms-appx:///Assets/{0}.jpg", imageName);
            }

            return "ms-appx:///Assets/NoImage.jpg";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
