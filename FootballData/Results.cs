using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public static async Task<bool> DataHasBeenUpdated(League league, Season season, DateTime sinceDate)
        {
            var config = Config.GetConfigFile();
            return await WebOps.GetLastModifiedTime(GenerateUrl(config, league.Id, season.Id)) > sinceDate;
        }

        /// <summary>
        /// Get all results for the requested league and season
        /// </summary>
        /// <param name="league">The league for which results should be returned</param>
        /// <param name="season">The season for which results should be returned</param>
        /// <returns></returns>
        public static async Task<ResultList> Get(League league, Season season)
        {
            var config = Config.GetConfigFile();
            var url = GenerateUrl(config, league.Id, season.Id);

            var data = await WebOps.GetCsvFile(url);
            var matches = CsvOps.GetMatchesFromCsv(data.File, season);

            var results = matches.Select(match => new Result(match)).ToList();

            return new ResultList() { Results = results, LastModifiedTime = data.LastModified };
        }

        private static string GenerateUrl(XDocument config, string leagueId, string season)
        {
            var baseUrl = Config.ResultUrl(config);
            var url = baseUrl
                .Replace("{season}", season)
                .Replace("{leagueId}", leagueId);
            return url;
        }
    }
}