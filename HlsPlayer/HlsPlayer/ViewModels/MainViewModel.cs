namespace HlsPlayer.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using System.Windows.Input;
    using Windows.Media.Streaming.Adaptive;
    using System;

    public class MainViewModel : ViewModelBase
    {
        // Consts
        private const string HlsUrl = "http://devimages.apple.com/iphone/samples/bipbop/bipbopall.m3u8";

        // Variables
        private AdaptiveMediaSource _mediaSource;

        // Commands
        private ICommand _playCommand;

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public AdaptiveMediaSource MediaSource
        {
            get { return _mediaSource; }
            set
            {
                _mediaSource = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PlayCommand
        {
            get { return _playCommand = _playCommand ?? new DelegateCommandAsync(PlayCommandExecute); }
        }

        private async Task PlayCommandExecute()
        {
            var hlsUri = new Uri(HlsUrl);
            var hlsSource = await AdaptiveMediaSource.CreateFromUriAsync(hlsUri);

            if (hlsSource.Status == AdaptiveMediaSourceCreationStatus.Success)
            {
                MediaSource = hlsSource.MediaSource;
            }
        }
    }
}
