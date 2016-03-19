namespace Print.ViewModels
{
    using System.Threading.Tasks;
    using Print.ViewModels.Base;
    using Windows.UI.Xaml.Navigation;
    using System.Windows.Input;
    using Services.Print;
    using Windows.UI.Xaml;
    using System.Collections.ObjectModel;
    using Helper;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private ObservableCollection<string> _products;

        // Commands
        private ICommand _printCommand;

        // Services
        private IPrintService _printService;

        public MainViewModel(IPrintService printService)
        {
            _printService = printService;
        }

        public ObservableCollection<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PrintCommand
        {
            get { return _printCommand = _printCommand ?? new DelegateCommand(PrintCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            _printService.UnregisterForPrinting();

            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            _printService.RegisterForPrinting();
            LoadProducts();

            return null;
        }

        private void PrintCommandExecute()
        {
            _printService.SetPrintContent(GetPrintableContent());

            _printService.ShowPrintUiAsync("Print Sample");
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<string>
            {
                "Milk",
                "Apples",
                "Water",
                "Chicken meat",
                "Coffee",
                "Yogurt",
            };
        }

        private UIElement GetPrintableContent()
        {
            return VisualHelper.FindChild<UIElement>(
                Window.Current.Content, "PrintableContent");
        }
    }
}
