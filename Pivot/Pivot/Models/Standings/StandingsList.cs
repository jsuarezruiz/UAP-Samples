using System.Collections.Generic;

namespace Pivot.Models
{
    public class StandingsList
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public List<DriverStanding> DriverStandings { get; set; }
        public List<ConstructorStanding> ConstructorStandings { get; set; }
    }
}
