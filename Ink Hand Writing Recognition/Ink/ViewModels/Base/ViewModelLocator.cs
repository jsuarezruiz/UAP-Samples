namespace Ink.ViewModels.Base
{
    using Services.Dialog;
    using Microsoft.Practices.Unity;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<InkViewModel>();

            // Services
            _container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());

        }

        public InkViewModel InkViewModel
        {
            get { return _container.Resolve<InkViewModel>(); }
        }
    }
}
