using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ParallaxEffect.Model
{
    [DataContract]
    public abstract class RecipeDataCommon : INotifyPropertyChanged
    {
        #region Privates

        internal static Uri _baseUri = new Uri("ms-appx:///");

        #endregion

        #region Constructor

        public RecipeDataCommon(String uniqueId, String title, String shortTitle, String imagePath)
        {
            _uniqueId = uniqueId;
            _title = title;
            _shortTitle = shortTitle;
            _imagePath = imagePath;
        }

        #endregion

        #region Properties

        private ImageSource _image;
        private string _imagePath;
        private string _shortTitle = string.Empty;
        private string _title = string.Empty;
        private string _uniqueId = string.Empty;

        [DataMember(Name = "key")]
        public string UniqueId
        {
            get { return _uniqueId; }
            set
            {
                _uniqueId = value;
                RaisePropertyChanged("UniqueId");
            }
        }

        [DataMember
            (Name = "title")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        [DataMember(Name = "shortTitle")]
        public string ShortTitle
        {
            get { return _shortTitle; }
            set
            {
                _shortTitle = value;
                RaisePropertyChanged("ShortTitle");
            }
        }

        public Uri ImagePath
        {
            get { return new Uri(_baseUri, _imagePath); }
        }

        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        [IgnoreDataMember]
        public ImageSource Image
        {
            get
            {
                if (_image == null && _imagePath != null)
                {
                    _image = new BitmapImage(new Uri(_baseUri, _imagePath));
                }
                return _image;
            }

            set
            {
                _imagePath = null;
                _image = value;

                RaisePropertyChanged("Image");
            }
        }

        #endregion

        #region Methods

        public void SetImage(String path)
        {
            _image = null;
            _imagePath = path;
            RaisePropertyChanged("Image");
        }

        public string GetImageUri()
        {
            return _imagePath;
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

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