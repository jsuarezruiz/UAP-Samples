namespace MultipleViews.ViewModels
{
    using Base;
    using System;
    using Views;
    using System.Windows.Input;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private int _mainViewId;

        // Commands
        private ICommand _createSecondaryViewCommand;

        public ICommand CreateSecondaryViewCommand
        {
            get { return _createSecondaryViewCommand = _createSecondaryViewCommand ?? new DelegateCommandAsync(CreateSecondaryViewCommandExecute); }
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            var _mainViewId = ApplicationView.GetApplicationViewIdForWindow(CoreWindow.GetForCurrentThread());
            App.MainViewId = _mainViewId;

            return null;
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        private async Task CreateSecondaryViewCommandExecute()
        {
            var newView = CoreApplication.CreateNewView();
            int newViewId = 0;

            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(SecondaryView), null);
                Window.Current.Content = frame;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });

            var viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
               newViewId,
               ViewSizePreference.Default,
               ApplicationView.GetForCurrentView().Id,
               ViewSizePreference.Default);
        }
    }
}