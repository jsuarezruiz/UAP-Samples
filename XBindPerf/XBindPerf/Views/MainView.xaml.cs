namespace XBindPerf
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Views;

    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        private void OnClear(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Content.Children.Clear();
        }

        private void OnBinding(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var date = DateTime.Now;
            var binding = new Binding();
            string diff = string.Empty;
            binding.Loaded += (s, args) =>
            {
                diff = (DateTime.Now - date).ToString();
                Diff.Text = diff;
            };

            Content.Children.Add(binding);
        }

        private void OnXBinding(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var date = DateTime.Now;
            var binding = new XBind();
            string diff = string.Empty;
            binding.Loaded += (s, args) =>
            {
                diff = (DateTime.Now - date).ToString();
                Diff.Text = diff;
            };

            Content.Children.Add(binding);
        }
    }
}
