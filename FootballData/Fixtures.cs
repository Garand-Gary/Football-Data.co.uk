using FootballData.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FootballData
{
    /// <summary>
    /// Container class for all operations related to fixtures
    /// </summary>
    public static class Fixtures
    {
        /// <summary>
        /// Find out if the fixtures source file has been updated
        /// </summary>
        /// <param name="sinceDate">The date since which to check if the data has been updated</param>
        /// <returns>Returns a boolean with "true" if the data has been updated since the provided date</returns>
        public static async Task<bool> DataHasBeenUpdated(DateTime sinceDate)
        {
            var config = Config.GetConfigFile();
            return await WebOps.GetLastModifiedTime(Config.FixturesUrl(config)) > sinceDate;
        }

        /// <summary>
        /// Returns the current list of fixtures based on the source file
        /// </summary>
        /// <returns>A List of Fixture objects</returns>
        public static async Task<FixtureList> Get()
        {
            var config = Config.GetConfigFile();
            var data = await WebOps.GetCsvFile(Config.FixturesUrl(config));
            var matches = CsvOps.GetMatchesFromCsv(data.File, Seasons.GetLatest());

            var fixtures = matches.Select(match => new Fixture(match)).ToList();

            return new FixtureList() { Fixtures = fixtures, LastModifiedTime = data.LastModified };
        }
    }
}
