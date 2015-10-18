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
            _container.RegisterType<RestaurantViewModel>();
		}

        public RestaurantViewModel RestaurantViewModel => _container.Resolve<RestaurantViewModel>();
	}
}
