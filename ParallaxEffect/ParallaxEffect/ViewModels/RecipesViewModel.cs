namespace ParallaxEffect.ViewModels
{
    using Base;
    using Model;
    using Services.Recipes;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;

    public class RecipesViewModel : ViewModelBase
    {
        // Variables
        private readonly RecipeRepository _recipeRepository;
        private RecipeDataItem _recipeDataItem;

        // Services
        private IRecipesService _recipesService;

        public RecipesViewModel(IRecipesService recipesService)
        {
            _recipesService = recipesService;

            _recipeRepository = new RecipeRepository();
        }

        public ObservableCollection<RecipeDataGroup> GroupedRecipes
        {
            get { return _recipeRepository.ItemGroups; }
        }
        public ObservableCollection<RecipeDataItem> Recipes
        {
            get; set;
        }

        public RecipeDataItem SelectedRecipeDataItem
        {
            get { return _recipeDataItem; }
            set
            {
                _recipeDataItem = value;
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override async Task OnNavigatedTo(NavigationEventArgs e)
        {
            var recipes = await _recipesService.Load("Data\\Recipes.json");
       
            var ds = new List<string>();
            RecipeDataGroup group = null;

            Recipes = new ObservableCollection<RecipeDataItem>();
            foreach (RecipeDataItem recipe in recipes)
            {
                Recipes.Add(recipe);
                if (!ds.Contains(recipe.Group.UniqueId))
                {
                    group = recipe.Group;
                    group.Items = new ObservableCollection<RecipeDataItem>();
                    ds.Add(recipe.Group.UniqueId);
                    _recipeRepository.ItemGroups.Add(group);
                }

                _recipeRepository.AssignedUserImages(recipe);
                if (group != null) group.Items.Add(recipe);
            }
        }
    }
}
