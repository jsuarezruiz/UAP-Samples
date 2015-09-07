namespace FormulaOnePerformance.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Models;
    using Services.Standings;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        //Services
        private readonly IStandingService _standingService;

        //Variables
        private int _year;
        private ObservableCollection<DriverStanding> _driverStanding;
        private ObservableCollection<ConstructorStanding> _constructorStanding;
        private List<byte[]> _memory;

        //Commands
        private ICommand _refreshCommand;

        //Constructor
        public MainViewModel(IStandingService standingService)
        {
            _standingService = standingService;

            _driverStanding = new ObservableCollection<DriverStanding>();
            _constructorStanding = new ObservableCollection<ConstructorStanding>();
        }

        public ObservableCollection<DriverStanding> DriverStanding
        {
            get { return _driverStanding; }
            set { _driverStanding = value; }
        }

        public ObservableCollection<ConstructorStanding> ConstructorStanding
        {
            get { return _constructorStanding; }
            set { _constructorStanding = value; }
        }

        public ICommand RefreshCommand
        {
            get { return _refreshCommand = _refreshCommand ?? new DelegateCommandAsync(RefreshCommandDelegate); }
        }

        public override System.Threading.Tasks.Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override async Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            _year = DateTime.Today.Year;
            await LoadStandingsData(_year);
        }

        private async Task LoadStandingsData(int year)
        {
            var driverStandings = await _standingService.GetSeasonDriverStandingsCollectionAsync(year.ToString());
            var drivers = driverStandings.StandingsLists.First().DriverStandings;

            DriverStanding.Clear();
            foreach (var driver in drivers)
            {
                DriverStanding.Add(driver);
            }

            var constructorStandings = await _standingService.GetSeasonConstructorStandingsCollectionAsync(year.ToString());
            var constructors = constructorStandings.StandingsLists.First().ConstructorStandings;

            ConstructorStanding.Clear();
            foreach (var constructor in constructors)
            {
                ConstructorStanding.Add(constructor);
            }
        }

        public async Task RefreshCommandDelegate()
        {
            _year--;
            await LoadStandingsData(_year);

            if(_year % 2 == 0)
                BusyThread();
            else
                MemoryThread();
        }

        private void BusyThread()
        {
            Debug.WriteLine("Start BusyThread");
            var r = new Random();

            for (int i = 0; i < r.Next(10000, 200000); i++)
            {
                int total = 0;
                for (int j = 0; j < r.Next(1000, 20000); j++)
                {
                    total = total + j;
                }
            }

            Debug.WriteLine("End BusyThread");
        }

        private void MemoryThread()
        {
            Debug.WriteLine("Start MemoryThread");

            var r = new Random();

            for (int i = 0; i < 5000; i++)
            {
                int size = r.Next(10000, 1000000);
                byte[] buffer = new byte[size];
                r.NextBytes(buffer);

                _memory.Add(buffer);
            }

            Debug.WriteLine("End MemoryThread");
        }
    }
}
