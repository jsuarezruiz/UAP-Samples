using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace ParallaxEffect.Model
{
    [DataContract]
    public class RecipeDataItem : RecipeDataCommon
    {
        private string _directions = string.Empty;
        private RecipeDataGroup _group;
        private ObservableCollection<string> _ingredients;
        private int _preptime;
        private ObservableCollection<string> _userImages;

        public RecipeDataItem()
            : base(String.Empty, String.Empty, String.Empty, String.Empty)
        {
            _userImages = new ObservableCollection<string>();
        }

        public RecipeDataItem(String uniqueId, String title, String shortTitle, String imagePath, int preptime,
            String directions, ObservableCollection<string> ingredients, RecipeDataGroup group)
            : base(uniqueId, title, shortTitle, imagePath)
        {
            _preptime = preptime;
            _directions = directions;
            _ingredients = ingredients;
            _group = group;
            _userImages = new ObservableCollection<string>();
        }

        [DataMember(Name = "preptime")]
        public int PrepTime
        {
            get { return _preptime; }
            set
            {
                _preptime = value;
                RaisePropertyChanged("PrepTime");
            }
        }

        [DataMember(Name = "directions")]
        public string Directions
        {
            get { return _directions; }
            set
            {
                _directions = value;
                RaisePropertyChanged("Directions");
            }
        }

        [DataMember(Name = "userImages")]
        public ObservableCollection<string> UserImages
        {
            get { return _userImages; }
            set
            {
                _userImages = value;
                RaisePropertyChanged("UserImages");
            }
        }

        [DataMember(Name = "ingredients")]
        public ObservableCollection<string> Ingredients
        {
            get { return _ingredients; }
            set
            {
                _ingredients = value;
                RaisePropertyChanged("Ingredients");
            }
        }

        public string IngredientsString
        {
            get
            {
                return Ingredients.Aggregate(string.Empty, (current, ingredient) => current + ingredient + Environment.NewLine);
            }
        }

        [DataMember(Name = "group")]
        public RecipeDataGroup Group
        {
            get { return _group; }
            set
            {
                _group = value;
                RaisePropertyChanged("Group");
            }
        }

        #region INotifyPropertyChanged Implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}