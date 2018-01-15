using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballData
{
    public static class Results
    {
        public static bool DataHasBeenUpdated(League league, Season season, DateTime sinceDate)
        {
            return WebOps.GetLastModifiedTime(GenerateUrl(league.Id, season.Id)) > sinceDate;
        }

        public static List<Result> Get(League league, Season season, out DateTime lastModifiedTime)
        {
            var url = GenerateUrl(league.Id, season.Id);

            var data = WebOps.GetCsvFile(url, out lastModifiedTime);
            var matches = CsvOps.GetMatchesFromCsv(data);

            var results = matches.Select(match => new Result(match)).ToList();

            return results;
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