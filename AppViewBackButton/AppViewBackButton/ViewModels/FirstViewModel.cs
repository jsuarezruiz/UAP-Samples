namespace AppViewBackButton.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Windows.Input;
	using Views;
	using System;

	public class FirstViewModel : ViewModelBase
	{
		private ICommand _goToSecondCommand;
		private ICommand _parameterCommand;

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
            base.OnNavigatedTo(args);

			return null;
		}

		public ICommand GoToSecondCommand
		{
			get { return _goToSecondCommand = _goToSecondCommand ?? new DelegateCommand(GoToSecondCommandExecute); }
		}

		public ICommand ParameterCommand
		{
			get { return _parameterCommand = _parameterCommand ?? new DelegateCommand(ParameterCommandExecute); }
		}

		private void GoToSecondCommandExecute()
		{
			AppFrame.Navigate(typeof(SecondView));
		}

		private void ParameterCommandExecute()
		{
			var rnd = new Random();
			AppFrame.Navigate(typeof(SecondView), rnd.Next(1, 100));
		}
    }
}
