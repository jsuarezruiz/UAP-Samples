using Pivot.Models;
using Pivot.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Pivot.ViewModels
{
    public class PivotViewModel : ViewModelBase
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
