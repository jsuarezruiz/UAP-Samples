namespace Design.ViewModels.Base
{
    using Microsoft.Practices.Unity;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<ShellViewModel>();
            _container.RegisterType<RestaurantViewModel>();
		}

        public ShellViewModel ShellViewModel => _container.Resolve<ShellViewModel>();
        public RestaurantViewModel RestaurantViewModel => _container.Resolve<RestaurantViewModel>();
	}
}