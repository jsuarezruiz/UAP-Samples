namespace MVVM.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Windows.Input;
	using Services.Dialog;

	public class MainViewModel : ViewModelBase
	{
		private IDialogService _dialogService;

		private ICommand _helloCommand;

		public MainViewModel(IDialogService dialogService)
		{
			_dialogService = dialogService;
		}

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			return null;
		}

		public ICommand HelloCommand
		{
			get { return _helloCommand = _helloCommand ?? new DelegateCommand(HelloCommandExecute); }
		}

		private void HelloCommandExecute()
		{
			_dialogService.Show("Hello World!");
        }
	}
}
