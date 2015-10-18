namespace Design.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class ToUpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format("{0}", value).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
