namespace Navigation.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Windows.Input;
	using Views;

	public class FirstViewModel : ViewModelBase
	{
		private ICommand _goToSecondCommand;

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			return null;
		}

		public ICommand GoToSecondCommand
		{
			get { return _goToSecondCommand = _goToSecondCommand ?? new DelegateCommand(GoToSecondCommandExecute); }
		}

		private void GoToSecondCommandExecute()
		{
			AppFrame.Navigate(typeof(SecondView));
		}
    }
}
