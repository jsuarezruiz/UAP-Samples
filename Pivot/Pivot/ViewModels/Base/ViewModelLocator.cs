namespace Pivot.ViewModels.Base
{
	using Services.Standings;
	using Microsoft.Practices.Unity;

	public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();
			_container.RegisterType<PivotViewModel>();
			_container.RegisterType<TabViewModel>();

			// Services
			_container.RegisterType<IStandingService, StandingService>(new ContainerControlledLifetimeManager());
		}

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

		public PivotViewModel PivotViewModel
        {
			get { return _container.Resolve<PivotViewModel>(); }
		}

		public TabViewModel TabViewModel
        {
			get { return _container.Resolve<TabViewModel>(); }
		}
	}
}
