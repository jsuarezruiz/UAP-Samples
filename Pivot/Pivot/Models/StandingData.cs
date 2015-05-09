using System.Collections.ObjectModel;

namespace Pivot.Models
{
    public class StandingData
    {
        public ObservableCollection<DriverStanding> Driver { get; set; }
        public ObservableCollection<ConstructorStanding> Constructor { get; set; }
    }
}
