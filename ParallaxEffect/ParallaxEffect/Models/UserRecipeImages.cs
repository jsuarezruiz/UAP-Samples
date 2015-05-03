using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ParallaxEffect.Model
{
    [DataContract]
    public class UserRecipeImages
    {
        #region Constructor

        public UserRecipeImages(string key, ObservableCollection<string> images)
        {
            UniqueId = key;
            Images = images;
        }

        #endregion

        #region Properties

        [DataMember(Name = "key")]
        public string UniqueId { get; set; }

        [DataMember(Name = "images")]
        public ObservableCollection<string> Images { get; set; }

        #endregion
    }
}