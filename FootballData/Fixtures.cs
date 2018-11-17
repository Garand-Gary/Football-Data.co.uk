using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public static bool DataHasBeenUpdated(DateTime sinceDate)
        {
            return WebOps.GetLastModifiedTime(Config.FixturesUrl) > sinceDate;
        }

        /// <summary>
        /// Returns the current list of fixtures based on the source file
        /// </summary>
        /// <param name="lastModifiedTime">Output parameter which will return the last modified time of the fetched fixtures file</param>
        /// <returns>A List of Fixture objects</returns>
        public static List<Fixture> Get(out DateTime lastModifiedTime)
        {
            var data = WebOps.GetCsvFile(Config.FixturesUrl, out lastModifiedTime);
            var matches = CsvOps.GetMatchesFromCsv(data, Seasons.GetLatest());

            var fixtures = matches.Select(match => new Fixture(match)).ToList();

            return fixtures;
        }

        /// <summary>
        /// Returns the current list of fixtures based on the source file
        /// </summary>
        /// <returns>A List of Fixture objects</returns>
        public static List<Fixture> Get()
        {
            // We need to delcare the lastModified parameter but we will chuck it away
            var lastModified = new DateTime();
            return Get(out lastModified);
        }
    }
}
