namespace ParallaxEffect.Services.Recipes
{
    using System;
    using Model;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.ApplicationModel;
    using Windows.Data.Json;
    using Windows.Storage;

    public class RecipesService : IRecipesService
    {
        public async Task<IEnumerable<RecipeDataItem>> Load(string filePath)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync(filePath);
            var result = await FileIO.ReadTextAsync(file);

            // Parse JSON 
            var data = JsonArray.Parse(result);

            var recipes = new List<RecipeDataItem>();
            foreach (var item in data)
            {
                var obj = item.GetObject();
                RecipeDataItem recipe = new RecipeDataItem();

                foreach (var key in obj.Keys)
                {
                    IJsonValue val;
                    if (!obj.TryGetValue(key, out val))
                        continue;

                    switch (key)
                    {
                        case "key":
                            recipe.UniqueId = val.GetNumber().ToString();
                            break;
                        case "title":
                            recipe.Title = val.GetString();
                            break;
                        case "shortTitle":
                            recipe.ShortTitle = val.GetString();
                            break;
                        case "preptime":
                            recipe.PrepTime = (int)val.GetNumber();
                            break;
                        case "directions":
                            recipe.Directions = val.GetString();
                            break;
                        case "ingredients":
                            var ingredients = val.GetArray();
                            var list = (from i in ingredients select i.GetString()).ToList();
                            recipe.Ingredients = new ObservableCollection<string>(list);
                            break;
                        case "backgroundImage":
                            recipe.SetImage(val.GetString());
                            break;
                        case "group":
                            var recipeGroup = val.GetObject();

                            IJsonValue groupKey;
                            if (!recipeGroup.TryGetValue("key", out groupKey))
                                continue;

                            var group = RecipeRepository.AllGroups.FirstOrDefault(c => c.UniqueId.Equals(groupKey.GetString()));

                            if (group == null)
                                group = CreateRecipeGroup(recipeGroup);

                            recipe.Group = group;
                            break;
                    }
                }

                recipes.Add(recipe);
            }

            return recipes;
        }

        public  RecipeDataGroup CreateRecipeGroup(JsonObject obj)
        {
            RecipeDataGroup group = new RecipeDataGroup();

            foreach (var key in obj.Keys)
            {
                IJsonValue val;
                if (!obj.TryGetValue(key, out val))
                    continue;

                switch (key)
                {
                    case "key":
                        group.UniqueId = val.GetString();
                        break;
                    case "title":
                        group.Title = val.GetString();
                        break;
                    case "shortTitle":
                        group.ShortTitle = val.GetString();
                        break;
                    case "description":
                        group.Description = val.GetString();
                        break;
                    case "backgroundImage":
                        group.SetImage(val.GetString());
                        break;
                    case "groupImage":
                        group.SetGroupImage(val.GetString());
                        break;
                }
            }

            RecipeRepository.AllGroups.Add(group);

            return group;
        }
    }
}
