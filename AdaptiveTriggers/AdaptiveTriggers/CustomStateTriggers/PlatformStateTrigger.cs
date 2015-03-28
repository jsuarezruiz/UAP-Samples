namespace AdaptiveTriggers.CustomStateTriggers
{
	using System.Linq;
	using Windows.ApplicationModel.Resources.Core;
	using Windows.UI.Xaml;

	public class PlatformStateTrigger : StateTriggerBase
	{
		private static string _deviceFamily;

		public PlatformStateTrigger()
		{
			var qualifiers = ResourceContext.GetForCurrentView().QualifierValues;
			_deviceFamily = qualifiers.First(q => q.Key.Equals("DeviceFamily")).Value;
		}

		public string Platform
		{
			get { return (string)GetValue(PlatformProperty); }
			set { SetValue(PlatformProperty, value); }
		}

		public static readonly DependencyProperty PlatformProperty =
		DependencyProperty.Register("Platform", typeof(string), typeof(PlatformStateTrigger),
		new PropertyMetadata(true, OnPlatformPropertyChanged));

		private static void OnPlatformPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var obj = (PlatformStateTrigger)d;
			var platform = (string)e.NewValue;

			if(_deviceFamily.Equals("Desktop"))
				obj.SetTriggerValue(platform == "Windows");
			else
				obj.SetTriggerValue(platform == "WindowsPhone");
		}
	}
}
