namespace FullScreenMode.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using System.Windows.Input;
    using Windows.UI.ViewManagement;
    using System.Diagnostics;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private bool _isFullScreenMode;

        // Commands
        private ICommand _fullScreenModeCommand;
        private ICommand _showOverlayControlsCommand;
        private ICommand _setFullScreenModeCommand;

        public MainViewModel()
        {
            IsFullScreenMode = ApplicationView.PreferredLaunchWindowingMode == ApplicationViewWindowingMode.FullScreen;

            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(600, 300);
        }

        public bool IsFullScreenMode
        {
            get { return _isFullScreenMode; }
            set
            {
                _isFullScreenMode = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public ICommand FullScreenModeCommand
        {
            get { return _fullScreenModeCommand = _fullScreenModeCommand ?? new DelegateCommand(FullScreenModeCommandExecute); }
        }

        public ICommand ShowOverlayControlsCommand
        {
            get { return _showOverlayControlsCommand = _showOverlayControlsCommand ?? new DelegateCommand(ShowOverlayControlsCommandExecute); }
        }

        public ICommand SetFullScreenModeCommand
        {
            get { return _setFullScreenModeCommand = _setFullScreenModeCommand ?? new DelegateCommand<bool>(SetFullScreenModeCommandExecute); }
        }

        private void ShowOverlayControlsCommandExecute()
        {
            var view = ApplicationView.GetForCurrentView();
            view.ShowStandardSystemOverlays();
        }

        private void FullScreenModeCommandExecute()
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
            }
            else
            {
                var result = view.TryEnterFullScreenMode();
                Debug.WriteLine(result);
            }
        }

        private void SetFullScreenModeCommandExecute(bool isChecked)
        {
            ApplicationView.PreferredLaunchWindowingMode = isChecked ? ApplicationViewWindowingMode.FullScreen : ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
    }
}
