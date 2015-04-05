namespace SplitView.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Collections.ObjectModel;
	using Models;

	public class StandingsViewModel : ViewModelBase
	{
		private ObservableCollection<DriverStanding> _driverStanding;

		public ObservableCollection<DriverStanding> DriverStanding
		{
			get { return _driverStanding; }
			set
			{
				_driverStanding = value;
				RaisePropertyChanged();
			}
		}

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			if (args.Parameter != null)
			{
				DriverStanding = args.Parameter as ObservableCollection<DriverStanding>;
			}

			return null;
		}
	}
}
