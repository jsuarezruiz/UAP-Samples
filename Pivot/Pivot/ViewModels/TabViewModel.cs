using System.Threading.Tasks;
using Pivot.ViewModels.Base;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Pivot.Models;

namespace Pivot.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        private ObservableCollection<DriverStanding> _driverStanding;
        private ObservableCollection<ConstructorStanding> _constructorStanding;

        public ObservableCollection<DriverStanding> DriverStanding
        {
            get { return _driverStanding; }
            set
            {
                _driverStanding = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ConstructorStanding> ConstructorStanding
        {
            get { return _constructorStanding; }
            set
            {
                _constructorStanding = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.Parameter != null)
            {
                var data = args.Parameter as StandingData;
                DriverStanding = data.Driver;
                ConstructorStanding = data.Constructor;
            }

            return null;
        }
    }
}
