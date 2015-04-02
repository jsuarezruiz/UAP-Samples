namespace DeviceFamily_View
{
	using System.Diagnostics;
	using Windows.UI.Xaml.Controls;

	public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			Debug.WriteLine("Lógica compartida!");
		}
	}
}
