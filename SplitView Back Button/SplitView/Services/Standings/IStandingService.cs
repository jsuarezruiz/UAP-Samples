using SplitView.Models;
using System.Threading.Tasks;

namespace SplitView.Services.Standings
{
    public interface IStandingService
    {
        Task<StandingTable> GetSeasonConstructorStandingsCollectionAsync(string season = "current");

        Task<StandingTable> GetSeasonDriverStandingsCollectionAsync(string season = "current");
    }
}
