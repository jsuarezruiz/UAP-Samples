using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BindingEvents.ViewModels;

namespace BindingEvents.Views
{
    public sealed partial class MainView : Page
    {
        public RoutedEventHandler ClickDelegate;

        public MainView()
        {
            this.InitializeComponent();

            ClickDelegate = this.Click_RegularArgs;
        }

        private void Click_RegularArgs(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            vm?.Show("Regular Args");
        }

        private void Click_NoArgs()
        {
            var vm = DataContext as MainViewModel;
            vm?.Show("No Args");
        }

        private void Click_BaseArgs(object sender, object e)
        {
            var vm = DataContext as MainViewModel;
            vm?.Show("Base Args");
        }
    }
}
