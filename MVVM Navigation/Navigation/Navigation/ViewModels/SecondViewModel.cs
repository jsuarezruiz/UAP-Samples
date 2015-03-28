namespace Navigation.ViewModels
{
	using Base;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Windows.UI.Xaml.Navigation;

	public class SecondViewModel : ViewModelBase
	{
		private ICommand _backCommand;

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			return null;
		}

		public ICommand BackCommand
		{
			get { return _backCommand = _backCommand ?? new DelegateCommand(BackCommandExecute); }
		}

		private void BackCommandExecute()
		{
			if (AppFrame.CanGoBack)
				AppFrame.GoBack();
		}
	}
}
