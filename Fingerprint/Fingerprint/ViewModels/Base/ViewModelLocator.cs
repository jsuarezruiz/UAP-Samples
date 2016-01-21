namespace Fingerprint.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.Dialog;
    using Services.UserConsentVerifier;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();

			// Services
			_container.RegisterType<IUserConsentVerifierService, UserConsentVerifierService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
	}
}
