namespace BindingEvents.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using Services.Dialog;
    using System.Collections.ObjectModel;
    using Models;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private ObservableCollection<House> _houses;

        // Services
        private IDialogService _dialogService;

        public ObservableCollection<House> Houses
        {
            get
            {
                if (_houses == null)
                    LoadHouses();

                return _houses;
            }
        }

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void Show(string message)
        {
            _dialogService.Show(message);
        }

        private void LoadHouses()
        {
            _houses = new ObservableCollection<House>();
            _houses.Add(new House
            {
                Name = "Home 1"
            });
            _houses.Add(new House
            {
                Name = "Home 2"
            });
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
