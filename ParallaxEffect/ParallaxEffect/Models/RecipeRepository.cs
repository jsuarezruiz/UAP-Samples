using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ParallaxEffect.Model
{
    public class RecipeRepository
    {
        public List<UserRecipeImages> UserImages = new List<UserRecipeImages>();
        private ObservableCollection<RecipeDataGroup> _itemGroups = new ObservableCollection<RecipeDataGroup>();
        public ObservableCollection<RecipeDataGroup> ItemGroups
        {
            get { return this._itemGroups; }
            set { this._itemGroups = value; }
        }

        private static ObservableCollection<RecipeDataGroup> _allGroups = new ObservableCollection<RecipeDataGroup>();
        public static ObservableCollection<RecipeDataGroup> AllGroups
        {
            get { return _allGroups; }
            set { _allGroups = value; }
        }

        public static IEnumerable<RecipeDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return AllGroups;
        }

        public static RecipeDataGroup GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static RecipeDataItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public RecipeDataGroup FindGroup(string uniqueId)
        {
            return (from g in ItemGroups where g.UniqueId == uniqueId select g).SingleOrDefault();
        }

        public RecipeDataItem FindRecipe(string uniqueId)
        {
            return ItemGroups.SelectMany(g => g.Items).SingleOrDefault(i => i.UniqueId == uniqueId);
        }

        public void AssignedUserImages(RecipeDataItem recipe)
        {
            if (UserImages != null && UserImages.Any(item => item.UniqueId.Equals(recipe.UniqueId)))
            {
                var userImages = UserImages.Single(a => a.UniqueId.Equals(recipe.UniqueId));
                recipe.UserImages = userImages.Images;
            }
        }
    }
}