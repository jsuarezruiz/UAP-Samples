using System.Threading.Tasks;
using AssetsDpiScale.ViewModels.Base;
using Windows.UI.Xaml.Navigation;
using Windows.Graphics.Display;

namespace AssetsDpiScale.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private DisplayInformation _displayInformation;
        private string _logicalDpi;
        private string _scale;

        public MainViewModel()
        {
            _displayInformation = DisplayInformation.GetForCurrentView();
        }

        public string LogicalDpi
        {
            get { return _logicalDpi; }
            set
            {
                _logicalDpi = value;
                RaisePropertyChanged();
            }
        }

        public string Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            _displayInformation.DpiChanged -= _displayInformation_DpiChanged;

            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            UpdateDpi(_displayInformation);
            _displayInformation.DpiChanged += _displayInformation_DpiChanged;

            return null;
        }

        private void _displayInformation_DpiChanged(DisplayInformation sender, object args)
        {
            DisplayInformation displayInformation = sender as DisplayInformation;

            UpdateDpi(displayInformation);
        }

        private void UpdateDpi(DisplayInformation displayInformation)
        {
            if (displayInformation != null)
            {
                LogicalDpi = displayInformation.LogicalDpi.ToString();
                Scale = (displayInformation.RawPixelsPerViewPixel * 100.0).ToString();
            }
        }
    }
}
