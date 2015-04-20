namespace SplitView.Converters
{
	using System;
	using Windows.UI.Xaml.Data;

	class ToUpperConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value.ToString().ToUpperInvariant();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
