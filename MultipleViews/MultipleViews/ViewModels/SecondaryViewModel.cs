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
            get { return _switchViewCommand = _switchViewCommand ?? new DelegateCommandAsync(SwitchViewCommandExecute); }
        }

        public ICommand HideViewCommand
        {
            get { return _hideViewCommand = _hideViewCommand ?? new DelegateCommandAsync(HideViewCommandExecute); }
        }

        private async Task SwitchViewCommandExecute()
        {
            await ApplicationViewSwitcher.SwitchAsync(App.MainViewId);
        }

        private async Task HideViewCommandExecute()
        {
            await ApplicationViewSwitcher.SwitchAsync(App.MainViewId,
                ApplicationView.GetForCurrentView().Id,
                ApplicationViewSwitchingOptions.ConsolidateViews);
        }
    }
}
