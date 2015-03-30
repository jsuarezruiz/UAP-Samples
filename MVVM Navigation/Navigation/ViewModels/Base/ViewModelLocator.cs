namespace Navigation.ViewModels.Base
{
	using Microsoft.Practices.Unity;

	public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<FirstViewModel>();
            _container.RegisterType<SecondViewModel>();
        }

        public FirstViewModel FirstViewModel
		{
            get { return _container.Resolve<FirstViewModel>(); }
        }

        public SecondViewModel SecondViewModel
		{
            get { return _container.Resolve<SecondViewModel>(); }
        }
    }
}
