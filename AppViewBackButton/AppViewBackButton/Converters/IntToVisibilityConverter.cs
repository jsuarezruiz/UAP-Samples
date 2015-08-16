namespace AppViewBackButton.Converters
{
	using System;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Data;

	public class IntToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var intValue = value as int?;

			if (intValue.HasValue)
				if (!intValue.Equals(0))
					return Visibility.Visible;

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
