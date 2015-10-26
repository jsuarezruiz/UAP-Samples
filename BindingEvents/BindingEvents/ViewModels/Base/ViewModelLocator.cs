namespace BindingEvents.ViewModels.Base
{
    using Services.Dialog;
    using Microsoft.Practices.Unity;
    using Models;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // Models
            _container.RegisterType<House>();

            // ViewModels
            _container.RegisterType<MainViewModel>();

            // Services
            _container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel => _container.Resolve<MainViewModel>();
    }
}