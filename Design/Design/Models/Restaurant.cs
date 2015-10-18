namespace Design.Models
{
    using System.Collections.ObjectModel;
    using Windows.Devices.Geolocation;

    public class Restaurant
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Position { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public Geopoint GeoLocation { get; set; }
        public Checkin Checkin { get; set; }
        public ObservableCollection<Review> Reviews { get; set; }
        public ObservableCollection<string> Images { get; set; }
    }
}
