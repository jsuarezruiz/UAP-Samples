namespace Print.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.Print;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();

			// Services
			_container.RegisterType<IPrintService, PrintService>(new ContainerControlledLifetimeManager());
            }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
	}
}
