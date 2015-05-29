namespace xBind_List.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Models;
    using Windows.UI.Xaml.Navigation;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        private string _time;
        private ObservableCollection<House> _houses;

        public List<string> Places
        {
            get
            {
                return new List<string>
                {
                    "Seville",
                    "Madrid",
                    "Málaga",
                    "Barcelona",
                    "Valencia",
                    "Paris",
                    "New York",
                    "San Francisco",
                    "London",
                    "Tokyo"
                };
            }
        }

        public ObservableCollection<House> Houses
        {
            get
            {
                if (_houses == null)
                    LoadHouses();

                return _houses;
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged();
            }
        }

        private void LoadHouses()
        {
            _houses = new ObservableCollection<House>();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                _houses.Add(new House
                {
                    Place = Places[random.Next(0, Places.Count)],
                    Photo = string.Format("ms-appx:///Assets/{0}.png", random.Next(1, 4)),
                    Price = string.Format("${0}", random.Next(10000, 100000).ToString())
                });
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }
    }
}
