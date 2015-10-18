namespace Design.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Navigation;
    using Models;
    using Base;

    public class RestaurantViewModel : ViewModelBase
    {
        private Restaurant _current;
        private readonly DispatcherTimer _timer;
        private int _selectedImage;

        public RestaurantViewModel()
        {
            //Configure the timer
            _timer = new DispatcherTimer
            {
                //Set the interval between ticks (in this case 2 seconds to see it working)
                Interval = TimeSpan.FromSeconds(2)
            };

            //Change what's displayed when the timer ticks
            _timer.Tick += ChangeImage;

            //Start the timer
            _timer.Start();
        }

        public Restaurant Current
        {
            get { return _current; }
            set
            {
                _current = value;
                RaisePropertyChanged();
            }
        }

        public int SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            LoadCurrentRestaurant();

            return null;
        }

        private void LoadCurrentRestaurant()
        {
            Current = new Restaurant
            {
                Name = "Burger Restaurant",
                Address = "803 Taylor Ave S (at Moi St)",
                Category = "American",
                Image = "BurgerRestaurant",
                Position = 1,
                GeoLocation = new Geopoint(new BasicGeoposition()
                {
                    // Seattle 
                    Latitude = 47.604,
                    Longitude = -122.329
                }),
                Checkin = new Checkin
                {
                    Today = 12,
                    Total = 1128
                },
                Reviews = LoadReviews(),
                Images = LoadImages()
            };
        }

        private ObservableCollection<Review> LoadReviews()
        {
            return new ObservableCollection<Review>
            {
                new Review
                {
                    Client = new Client
                    {
                        FullName = "Laura Ruiz",
                        Photo = "Client1"
                    },
                    Date = DateTime.Now.AddDays(-1),
                    Description = "It's overhyped and the line makes it almost not worth it. The burgers are always cooked well consistently and the fries are excellent."
                },
                new Review
                {
                    Client = new Client
                    {
                        FullName = "Scott Jordan",
                        Photo = "Client2"
                    },
                    Date = DateTime.Now.AddDays(-2),
                    Description = "The burger taste alright but it's not worth to wait a long line for thirty minutes."
                },
                new Review
                {
                    Client = new Client
                    {
                        FullName = "Anonymous",
                        Photo = "NoPhoto"
                    },
                    Date = DateTime.Now.AddDays(-3),
                    Description = "Cheeseburger with The Works- The works is w/lettuce, tomato, onion, sliced pickles, mustard, ketchup, and mayo. The burger looks like a hot mess, it is not photo friendly at all. I thought the burger was just OK. I had a few issues with the burger, I thought the beef itself had no flavor and to make it worse, I don't think the burger was seasoned at all. In terms of the burger as a whole, I really only remember tasting pickles, mustard and onions. The bun did have a nice chew which was nice."
                },
                new Review
                {
                    Client = new Client
                    {
                        FullName = "Anonymous",
                        Photo = "NoPhoto"
                    },
                    Date = DateTime.Now.AddDays(-3),
                    Description ="Simple, the best!. The burgers are always cooked well consistently and the fries are excellent."
                }
            };
        }

        private ObservableCollection<string> LoadImages()
        {
            return new ObservableCollection<string>
            {
                "Burger1",
                "Burger2",
                "Burger3",
                "Burger4",
                "Burger5",
                "Burger6"
            };
        }

        private void ChangeImage(object sender, object o)
        {
            //Get the number of items
            var totalItems = Current.Images.Count;
            //Figure out the new item's index (the current index plus one, if the next item would be out of range, go back to zero)
            var newItemIndex = (SelectedImage + 1) % totalItems;
            //Set the displayed item's index 
            SelectedImage = newItemIndex;
        }
    }
}