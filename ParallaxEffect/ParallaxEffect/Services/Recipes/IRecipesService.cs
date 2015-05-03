namespace ParallaxEffect.Services.Recipes
{
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.Data.Json;

    public interface IRecipesService
    {
        Task<IEnumerable<RecipeDataItem>> Load(string filePath);
        RecipeDataGroup CreateRecipeGroup(JsonObject obj);
    }
}
