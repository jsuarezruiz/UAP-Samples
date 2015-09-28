namespace CalculatorAppServiceProvider.ViewModels
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;
    using Services.Package;

    using Base;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private string _packageFamilyName;

        // Services
        private readonly IPackageService _packageService;

        public MainViewModel(IPackageService packageService)
        {
            _packageService = packageService;
        }

        public string PackageFamilyName
        {
            get { return _packageFamilyName; }
            set
            {
                _packageFamilyName = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            PackageFamilyName = _packageService.GetPackageFamilyName();
            Debug.WriteLine(PackageFamilyName);

            return null;
        }
    }
}
