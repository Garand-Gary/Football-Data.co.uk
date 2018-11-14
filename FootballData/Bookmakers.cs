using FootballData.Entities;
using System.Collections.Generic;

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
