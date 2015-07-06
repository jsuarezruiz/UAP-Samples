namespace InteractionMode.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.ViewManagement;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private string _userInteractionMode;

        public string InteractionMode
        {
            get { return _userInteractionMode; }
            set
            {
                _userInteractionMode = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            GetUserInteractiveMode();

            return null;
        }

        private void GetUserInteractiveMode()
        {
            var userInteractiveMode = UIViewSettings.GetForCurrentView().UserInteractionMode;

            switch (userInteractiveMode)
            {
                case UserInteractionMode.Mouse:
                    InteractionMode = "Ratón";
                    break;
                case UserInteractionMode.Touch:
                    InteractionMode = "Táctil";
                    break;
            }
        }
    }
}