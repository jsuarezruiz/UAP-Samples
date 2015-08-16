namespace MultipleViews.ViewModels
{
    using Base;
    using System;
    using System.Windows.Input;
    using Windows.UI.ViewManagement;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;

    public class SecondaryViewModel : ViewModelBase
    {
        // Commands
        private ICommand _switchViewCommand;
        private ICommand _hideViewCommand;

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public ICommand SwitchViewCommand
        {
            get { return _switchViewCommand = _switchViewCommand ?? new DelegateCommand(SwitchViewCommandExecute); }
        }

        public ICommand HideViewCommand
        {
            get { return _hideViewCommand = _hideViewCommand ?? new DelegateCommand(HideViewCommandExecute); }
        }

        private async void SwitchViewCommandExecute()
        {
            await ApplicationViewSwitcher.SwitchAsync(App.MainViewId);
        }

        private async void HideViewCommandExecute()
        {
            await ApplicationViewSwitcher.SwitchAsync(App.MainViewId,
                ApplicationView.GetForCurrentView().Id,
                ApplicationViewSwitchingOptions.ConsolidateViews);
        }
    }
}
