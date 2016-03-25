using System.Threading.Tasks;
using Advertising.ViewModels.Base;
using Windows.UI.Xaml.Navigation;
using System.Windows.Input;
using Microsoft.Advertising.WinRT.UI;
using Advertising.Services.Dialog;

namespace Advertising.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _applicationId;
        private string _videoIntersticialId;
        private InterstitialAd _interstitialAd;

        private ICommand _videoIntersticialCommand;

        private IDialogService _dialogService;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            // Instantiate the interstitial video ad
            _interstitialAd = new InterstitialAd();

            // Attach event handlers
            _interstitialAd.ErrorOccurred += OnAdError;
            _interstitialAd.AdReady += OnAdReady;
            _interstitialAd.Cancelled += OnAdCancelled;
            _interstitialAd.Completed += OnAdCompleted;
        }

        public string ApplicationId
        {
            get { return _applicationId; }
            set
            {
                _applicationId = value;
                RaisePropertyChanged();
            }
        }

        public string VideoIntersticialId
        {
            get { return _videoIntersticialId; }
            set
            {
                _videoIntersticialId = value;
                RaisePropertyChanged();
            }
        }

        public ICommand VideoIntersticialCommand
        {
            get { return _videoIntersticialCommand = _videoIntersticialCommand ?? new DelegateCommand(VideoIntersticialCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            SetAdsConf();

            return null;
        }

        private void SetAdsConf()
        {
            ApplicationId = "d25517cb-12d4-4699-8bdc-52040c712cab";
            VideoIntersticialId = "11389925";
        }

        private void VideoIntersticialCommandExecute()
        {
            _interstitialAd.RequestAd(AdType.Video,
                ApplicationId,               
                VideoIntersticialId);
        }

        private void OnAdReady(object sender, object e)
        {
            _interstitialAd.Show();
        }

        private async void OnAdCancelled(object sender, object e)
        {
            await _dialogService.ShowAsync("Ad cancelled");
        }

        private async void OnAdCompleted(object sender, object e)
        {
            await _dialogService.ShowAsync("Ad completed");
        }

        private async void OnAdError(object sender, AdErrorEventArgs e)
        {
            await _dialogService.ShowAsync($"An error occurred. {e.ErrorCode}: {e.ErrorMessage}");
        }
    }
}