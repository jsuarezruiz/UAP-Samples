namespace TitleBar.ViewModels
{
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;
    using Base;
    using System.Windows.Input;
    using TitleBar.Views;

    public class MainViewModel : ViewModelBase
    {
        private ICommand _navigateCommand;
        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand(NavigateCommandExecute); }
        }

        private void NavigateCommandExecute()
        {
            AppFrame.Navigate(typeof(BehaviorView));
        }
    }
}
