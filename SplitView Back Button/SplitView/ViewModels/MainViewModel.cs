namespace SplitView.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Windows.Input;
	using System.Collections.ObjectModel;
	using Models;
	using Views;
	using Services.Standings;
	using System.Linq;
	using System;

	public class MainViewModel : ViewModelBase
	{
		// Variables
		private bool _isPaneOpen;
		private ObservableCollection<MenuItem> _menuItems;
		private MenuItem _selectedMenuItem;
		private ObservableCollection<DriverStanding> _driverStanding;

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

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			return null;
		}

		public override async Task OnNavigatedTo(NavigationEventArgs args)
		{
			IsPaneOpen = true;

            await LoadDriverStanding();
			LoadMenu();
		}

		private void LoadMenu()
		{
			MenuItems = new ObservableCollection<MenuItem>
			{
				new MenuItem
				{
					Icon = "",
                    Title = "Home",
					View = typeof(HomeView)
				},
				new MenuItem
				{
					Icon = "",
					Title = "Standings",
					View = typeof(StandingsView)
				},
				new MenuItem
				{
					Icon = "",
                    Title = "About",
					View = typeof(AboutView)
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

		private void Navigate(Type view)
		{
			var type = view.Name;

			switch (type)
			{
				case "HomeView":
					SplitViewFrame.Navigate(view, _driverStanding);
					break;
				case "StandingsView":
					SplitViewFrame.Navigate(view, _driverStanding);
					break;
				case "AboutView":
					SplitViewFrame.Navigate(view);
					break;
			}

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
	}
}
