namespace TitleBar
{
    using Views.Base;
    using Windows.UI;
    using Windows.UI.ViewManagement;

    public sealed partial class MainView : PageBase
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        private void CodeBehindClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();

            // Title
            applicationView.Title = "Changed basic TitleBar Information";

            // Basic TitleBar Properties
            var titleBar = applicationView.TitleBar;
            titleBar.BackgroundColor = (Color)App.Current.Resources["RedColor"];
            titleBar.ForegroundColor = (Color)App.Current.Resources["WhiteColor"];
            titleBar.ButtonBackgroundColor = (Color)App.Current.Resources["BlueColor"];
            titleBar.ButtonForegroundColor = (Color)App.Current.Resources["WhiteColor"];

            // Extra
            titleBar.ButtonHoverBackgroundColor = Colors.Yellow;
            titleBar.ButtonPressedBackgroundColor = Colors.Orange;
        }
    }
}