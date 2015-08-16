namespace AppViewBackButton.ViewModels
{
    using Base;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Windows.UI.Xaml.Navigation;

    public class SecondViewModel : ViewModelBase
	{
		// Variables
		private int _parameter;

		// Commands
		private ICommand _backCommand;

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			if (args.Parameter != null)
			{
				Parameter = Convert.ToInt32(args.Parameter);
            }

            base.OnNavigatedTo(args);

            return null;
		}

		public int Parameter
		{
			get { return _parameter; }
			set
			{
				_parameter = value;
				RaisePropertyChanged();
			}
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
