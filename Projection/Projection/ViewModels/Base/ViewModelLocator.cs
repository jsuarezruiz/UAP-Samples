namespace Projection.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.Projection;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<ProjectionViewModel>();

            // Services
            _container.RegisterType<IProjectionService, ProjectionService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public ProjectionViewModel ProjectionViewModel
        {
            get { return _container.Resolve<ProjectionViewModel>(); }
        }
    }
}
