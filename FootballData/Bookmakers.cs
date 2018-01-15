using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    public static class Bookmakers
    {
        public static List<Bookmaker> Get()
        {
            return Config.GetBookmakers();
        }
    }
}
