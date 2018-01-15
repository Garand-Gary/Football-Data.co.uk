using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    /// <summary>
    /// Container class for all bookmakers within the library
    /// </summary>
    public static class Bookmakers
    {
        /// <summary>
        /// Returns a list of all bookmakers within the library
        /// </summary>
        /// <returns></returns>
        public static List<Bookmaker> Get()
        {
            return Config.GetBookmakers();
        }
    }
}
