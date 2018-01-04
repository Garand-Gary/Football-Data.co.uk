﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    public static class Results
    {
        public static bool DataHasBeenUpdated(string leagueId, string season, DateTime sinceDate)
        {
            return WebOps.GetLastModifiedTime(GenerateUrl(leagueId, season)) > sinceDate;
        }

        public static List<Result> Get(string leagueId, string season, out DateTime lastModifiedTime)
        {
            // TODO: Return a proper type, not a string
            var url = GenerateUrl(leagueId, season);

            var data = WebOps.GetCsvFile(url, out lastModifiedTime);


            return new List<Result>();
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