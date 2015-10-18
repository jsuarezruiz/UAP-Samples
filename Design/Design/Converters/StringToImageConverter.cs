namespace Design.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format("ms-appx:///Assets/{0}.jpg", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}