namespace XBindPerf.Views
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public sealed partial class XBind : Page
    {
        public XBind()
        {
            this.InitializeComponent();
        }

        public SolidColorBrush BackgroundA
        {
            get { return App.Current.Resources["BackgroundA"] as SolidColorBrush; }
        }

        public SolidColorBrush BackgroundB
        {
            get { return App.Current.Resources["BackgroundB"] as SolidColorBrush; }
        }

        public SolidColorBrush BackgroundC
        {
            get { return App.Current.Resources["BackgroundC"] as SolidColorBrush; }
        }

        public SolidColorBrush BackgroundD
        {
            get { return App.Current.Resources["BackgroundD"] as SolidColorBrush; }
        }
    }
}
