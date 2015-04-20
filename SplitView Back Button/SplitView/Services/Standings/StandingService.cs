using SplitView.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SplitView.Services.Standings
{
    public class StandingService : IStandingService
    {
        public async Task<StandingTable> GetSeasonConstructorStandingsCollectionAsync(string season = "current")
        {
            var url = string.Format("http://ergast.com/api/f1/{0}/constructorStandings.json", season);
            var client = new HttpClient();
            var stringResult = await client.GetStringAsync(new Uri(url));
            var data = JsonConvert.DeserializeObject<StandingRootObject>(stringResult);

            return data.MRData.StandingsTable;
        }

        public async Task<StandingTable> GetSeasonDriverStandingsCollectionAsync(string season = "current")
        {
            var url = string.Format("http://ergast.com/api/f1/{0}/driverStandings.json", season);
            var client = new HttpClient();
            var stringResult = await client.GetStringAsync(new Uri(url));
            var data = JsonConvert.DeserializeObject<StandingRootObject>(stringResult);

            return data.MRData.StandingsTable;
        }
    }
}
