using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    static class Config
    {
        internal static string ResultUrl { get { return "http://www.football-data.co.uk/mmz4281/{season}/{leagueId}.csv"; } }
        internal static string FixturesUrl { get { return "http://www.football-data.co.uk/fixtures.csv"; } }
    }
}
