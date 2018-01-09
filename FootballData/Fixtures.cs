using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballData
{
    public static class Fixtures
    {
        public static bool DataHasBeenUpdated(DateTime sinceDate)
        {
            return WebOps.GetLastModifiedTime(Config.FixturesUrl) > sinceDate;
        }

        public static List<Fixture> Get(out DateTime lastModifiedTime)
        {
            var data = WebOps.GetCsvFile(Config.FixturesUrl, out lastModifiedTime);
            var matches = CsvOps.GetMatchesFromCsv(data);

            var fixtures = matches.Select(match => new Fixture(match)).ToList();

            return fixtures;
        }
    }
}
