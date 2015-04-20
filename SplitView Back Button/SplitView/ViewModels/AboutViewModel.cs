namespace SplitView.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using Services.Package;

	public class AboutViewModel : ViewModelBase
	{
		// Variables
		private string _name;
		private string _version;

		// Services
		private IPackageService _packageService;

		public AboutViewModel(IPackageService packageService)
		{
			_packageService = packageService;
        }

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged();
			}
		}

		public string Version
		{
			get { return _version; }
			set
			{
				_version = value;
				RaisePropertyChanged();
			}
		}

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			Name = _packageService.GetAppName();
			Version = _packageService.GetVersion();

			return null;
		}
	}
}
