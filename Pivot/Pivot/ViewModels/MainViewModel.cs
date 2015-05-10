namespace Pivot.ViewModels
{
    using Models;
    using Services.Standings;
    using Base;
    using Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Windows.UI.Xaml.Navigation;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private bool _isPaneOpen;
        private ObservableCollection<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;
        private ObservableCollection<DriverStanding> _driverStanding;
        private ObservableCollection<ConstructorStanding> _constructorStanding;

        //Services
        private IStandingService _standingService;

        // Commands
        private ICommand _hamburgerCommand;
        private ICommand _navigateCommand;
        private DelegateCommand _backCommand;

        public MainViewModel(IStandingService standingService)
        {
            _standingService = standingService;
        }

        public bool IsPaneOpen
        {
            get
            {
                return _isPaneOpen;
            }
            set
            {
                _isPaneOpen = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged();
            }
        }

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                RaisePropertyChanged();
            }
        }

        public ICommand HamburgerCommand
        {
            get { return _hamburgerCommand = _hamburgerCommand ?? new DelegateCommand(HamburgerCommandExecute); }
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand<MenuItem>(NavigateCommandExecute); }
        }

        public DelegateCommand BackCommand
        {
            get { return _backCommand = _backCommand ?? new DelegateCommand(BackCommandExecute, BackCommandCanExecute); }
        }

        private void LoadMenu()
        {
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Icon = "",
                    Title = "Pivot",
                    View = typeof(PivotView)
                },
                new MenuItem
                {
                    Icon = "",
                    Title = "Tab",
                    View = typeof(TabView)
                }
            };

            SelectedMenuItem = MenuItems.FirstOrDefault();
            Navigate(SelectedMenuItem.View);
        }

        private async Task LoadDriverStanding()
        {
            var driverStandings = await _standingService.GetSeasonDriverStandingsCollectionAsync();
            var drivers = driverStandings.StandingsLists.First().DriverStandings;

            _driverStanding = new ObservableCollection<DriverStanding>();
            foreach (var driver in drivers)
            {
                _driverStanding.Add(driver);
            }
        }

        private async Task LoadConstructorStanding()
        {
            var constructorStandings = await _standingService.GetSeasonConstructorStandingsCollectionAsync();
            var constructors = constructorStandings.StandingsLists.First().ConstructorStandings;

            _constructorStanding = new ObservableCollection<ConstructorStanding>();
            foreach (var constructor in constructors)
            {
                _constructorStanding.Add(constructor);
            }
        }

        private void Navigate(Type view)
        {
            var type = view.Name;

            var standing = new StandingData
            {
                Driver = _driverStanding,
                Constructor = _constructorStanding
            };

            SplitViewFrame.Navigate(view, standing);
            BackCommand.RaiseCanExecuteChanged();
        }

        private void HamburgerCommandExecute()
        {
            IsPaneOpen = (IsPaneOpen == true) ? false : true;
        }

        private void NavigateCommandExecute(MenuItem menuItem)
        {
            Navigate(menuItem.View);
        }

        private void BackCommandExecute()
        {
            SplitViewFrame.GoBack();
            var selectedMenuItem = SplitViewFrame.CurrentSourcePageType;
            SelectedMenuItem = MenuItems.FirstOrDefault(mi => mi.View.Equals(selectedMenuItem));
        }

        private bool BackCommandCanExecute()
        {
            return SplitViewFrame.CanGoBack;
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override async Task OnNavigatedTo(NavigationEventArgs args)
        {
            IsPaneOpen = true;

            await LoadDriverStanding();
            await LoadConstructorStanding();

            LoadMenu();
        }
    }
}
