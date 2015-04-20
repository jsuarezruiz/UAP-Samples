namespace SplitView.ViewModels.Base
{
	using Services.Standings;
	using Microsoft.Practices.Unity;
	using Services.Package;

	public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();
			_container.RegisterType<HomeViewModel>();
			_container.RegisterType<StandingsViewModel>();
			_container.RegisterType<AboutViewModel>();

			// Services
			_container.RegisterType<IStandingService, StandingService>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
		}

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

		public HomeViewModel HomeViewModel
		{
			get { return _container.Resolve<HomeViewModel>(); }
		}

		public StandingsViewModel StandingsViewModel
		{
			get { return _container.Resolve<StandingsViewModel>(); }
		}

		public AboutViewModel AboutViewModel
		{
			get { return _container.Resolve<AboutViewModel>(); }
		}
	}
}
