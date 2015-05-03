using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ParallaxEffect.Model
{
    [DataContract]
    public class RecipeDataGroup : RecipeDataCommon
    {
        private string _description = string.Empty;
        private ImageSource _groupImage;
        private string _groupImagePath;
        private ObservableCollection<RecipeDataItem> _items = new ObservableCollection<RecipeDataItem>();

        public RecipeDataGroup()
            : base(String.Empty, String.Empty, String.Empty, String.Empty)
        {
        }

        public RecipeDataGroup(String uniqueId, String title, String shortTitle, String imagePath, String description)
            : base(uniqueId, title, shortTitle, imagePath)
        {
        }

        public bool LicensedRequired { get; set; }

        [DataMember(Name = "group")]
        public ObservableCollection<RecipeDataItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        [DataMember(Name = "description")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        [DataMember(Name = "groupImage")]
        public string GroupImagePath
        {
            get { return _groupImagePath; }
            set { _groupImagePath = value; }
        }

        [IgnoreDataMember]
        public ImageSource GroupImage
        {
            get
            {
                if (_groupImage == null && _groupImagePath != null)
                {
                    _groupImage = new BitmapImage(new Uri(_baseUri, _groupImagePath));
                }
                return _groupImage;
            }
            set
            {
                _groupImagePath = null;
                _groupImage = value;
                RaisePropertyChanged("GroupImage");
            }
        }

        public int RecipesCount
        {
            get { return Items.Count; }
        }

        public void SetGroupImage(String path)
        {
            _groupImage = null;
            _groupImagePath = path;
            RaisePropertyChanged("GroupImage");
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