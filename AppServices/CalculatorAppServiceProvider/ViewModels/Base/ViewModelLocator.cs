namespace CalculatorAppServiceProvider.ViewModels.Base
{
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

            // Services
            _container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel => _container.Resolve<MainViewModel>();
    }
}
