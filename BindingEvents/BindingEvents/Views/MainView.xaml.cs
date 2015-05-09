namespace BindingEvents
{
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainView : Page
    {
        public RoutedEventHandler clickDelegate;

        public MainView()
        {
            this.InitializeComponent();

            clickDelegate = this.Click_RegularArgs;
        }

        private void Click_RegularArgs(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
                vm.Show("Regular Args");
        }

        private void Click_NoArgs()
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
                vm.Show("No Args");
        }

        private void Click_BaseArgs(object sender, object e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
                vm.Show("Base Args");
        }
    }
}
