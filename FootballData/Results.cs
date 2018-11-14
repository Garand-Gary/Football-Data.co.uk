using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballData
{
    /// <summary>
    /// Container class for all operations related to results
    /// </summary>
    public static class Results
    {
        /// <summary>
        /// Find out if the results source file has been updated for the requested league and season
        /// </summary>
        /// <param name="league">The league for which the data file should be checked</param>
        /// <param name="season">The season for which the data file should be checked</param>
        /// <param name="sinceDate">The date since which to check if the data has been updated</param>
        /// <returns>Returns a boolean with "true" if the data has been updated since the provided date</returns>
        public static bool DataHasBeenUpdated(League league, Season season, DateTime sinceDate)
        {
            return WebOps.GetLastModifiedTime(GenerateUrl(league.Id, season.Id)) > sinceDate;
        }

        /// <summary>
        /// Get all results for the requested league and season
        /// </summary>
        /// <param name="league">The league for which results should be returned</param>
        /// <param name="season">The season for which results should be returned</param>
        /// <param name="lastModifiedTime">Output parameter which will show the last modified time of the results file</param>
        /// <returns></returns>
        public static List<Result> Get(League league, Season season, out DateTime lastModifiedTime)
        {
            var url = GenerateUrl(league.Id, season.Id);

            var data = WebOps.GetCsvFile(url, out lastModifiedTime);
            var matches = CsvOps.GetMatchesFromCsv(data);

            var results = matches.Select(match => new Result(match)).ToList();

            return results;
        }

        /// <summary>
        /// Get all results for the requested league and season
        /// </summary>
        /// <param name="league">The league for which results should be returned</param>
        /// <param name="season">The season for which results should be returned</param>
        /// <returns></returns>
        public static List<Result> Get(League league, Season season)
        {
            // Create a last modified parameter to satisfy the core method, but don't use it
            var lastModified = new DateTime();
            return Get(league, season, out lastModified);
        }

        private static string GenerateUrl(string leagueId, string season)
        {
            var baseUrl = Config.ResultUrl;
            var url = baseUrl
                .Replace("{season}", season)
                .Replace("{leagueId}", leagueId);
            return url;
        }
    }
}