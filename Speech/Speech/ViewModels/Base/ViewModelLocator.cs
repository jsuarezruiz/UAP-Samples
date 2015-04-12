namespace Speech.ViewModels.Base
{
	using Microsoft.Practices.Unity;
	using Services.Speech;

	public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<MainViewModel>();

			_container.RegisterType<ISpeechService, SpeechService>(new ContainerControlledLifetimeManager());
		}

        public MainViewModel MainViewModel
		{
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}
