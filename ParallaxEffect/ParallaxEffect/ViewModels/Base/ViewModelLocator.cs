namespace ParallaxEffect.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.Recipes;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<RecipesViewModel>();
            
            //Services
            _container.RegisterType<IRecipesService, RecipesService>();
        }

        public RecipesViewModel RecipesViewModel
        {
            get { return _container.Resolve<RecipesViewModel>(); }
        }
    }
}
