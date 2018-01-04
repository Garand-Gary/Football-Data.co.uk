using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            return null;
        }
    }
}
