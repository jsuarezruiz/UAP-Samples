namespace SplitView.Converters
{
	using System;
	using Windows.UI;
	using Windows.UI.Xaml.Data;
	using Windows.UI.Xaml.Media;

	public class AlternatingIndexConverter : IValueConverter
	{
		private static int _index;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (_index++ % 2 == 0 ? new SolidColorBrush(Colors.Transparent) : new SolidColorBrush(Colors.Gray));
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
