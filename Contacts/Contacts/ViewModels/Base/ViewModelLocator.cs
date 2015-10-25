namespace Contacts.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.Contacts;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<AddContactViewModel>();
            _container.RegisterType<ContactChangesViewModel>();
            _container.RegisterType<ContactsViewModel>();
            _container.RegisterType<PickViewModel>();
            _container.RegisterType<ShellViewModel>();

            // Services
            _container.RegisterType<IContactService, ContactService>(new ContainerControlledLifetimeManager());
        }

        public AddContactViewModel AddContactViewModel => _container.Resolve<AddContactViewModel>();
        public ContactsViewModel ContactsViewModel => _container.Resolve<ContactsViewModel>();
        public ContactChangesViewModel ContactChangesViewModel => _container.Resolve<ContactChangesViewModel>();
        public PickViewModel PickViewModel => _container.Resolve<PickViewModel>();
        public ShellViewModel ShellViewModel => _container.Resolve<ShellViewModel>();
    }
}