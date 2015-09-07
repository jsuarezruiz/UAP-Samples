using FormulaOnePerformance.Models;
using System.Threading.Tasks;

namespace FormulaOnePerformance.Services.Standings
{
    public interface IStandingService
    {
        Task<StandingTable> GetSeasonConstructorStandingsCollectionAsync(string season = "current");

        Task<StandingTable> GetSeasonDriverStandingsCollectionAsync(string season = "current");
    }
}
