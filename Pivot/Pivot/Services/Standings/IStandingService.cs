using Pivot.Models;
using System.Threading.Tasks;

namespace Pivot.Services.Standings
{
    public interface IStandingService
    {
        Task<StandingsTable> GetSeasonConstructorStandingsCollectionAsync(string season = "current");

        Task<StandingsTable> GetSeasonDriverStandingsCollectionAsync(string season = "current");
    }
}
