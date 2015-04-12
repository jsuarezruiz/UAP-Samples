namespace Speech.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Windows.Input;
	using Services.Speech;

	public class MainViewModel : ViewModelBase
	{
		// Commands
		private ICommand _speechCommand;

		// Services
		private ISpeechService _speechService;

		public MainViewModel(ISpeechService speechService)
		{
			_speechService = speechService;
        }

		public string Message
		{
			get { return "Windows 10 provides the ability to use a single UI that can adapt from small to large screens. For developers with an existing Windows 8.1 app, you can quickly try this one out by (a) removing one of your UI projects (and going from three Visual Studio projects to one!) and (b) add the improved ViewStateManager to control how your UI adapts at runtime."; }
		}

		public ICommand SpeechCommand
		{
			get { return _speechCommand = _speechCommand ?? new DelegateCommandAsync(SpeechCommandDelegate); }
		}

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			return null;
		}

		public async Task SpeechCommandDelegate()
		{
			if (_speechService.State.Equals(SpeechService.SpeechState.Stopped))
				await _speechService.Start(Message);
			else
				_speechService.Stop();
		}
	}
}
