using System.Collections.Generic;

namespace Pivot.Models
{
    public class StandingsTable
    {
        public string season { get; set; }
        public List<StandingsList> StandingsLists { get; set; }
    }
}