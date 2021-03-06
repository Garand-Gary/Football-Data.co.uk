﻿using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    /// <summary>
    /// Container class for all the seasons for which football-data.co.uk holds data
    /// </summary>
    public static class Seasons
    {
        // We'll generate seasons on the fly here. Seasons could go in the config 
        // file but that would mean changing that once a year forever more. The 
        // earliest data is for 93/94, so we'll generate them back to then.

        // At the time of writing this code (during 17/18 season) the earliest 
        // result record for this season was on 28/07. We'll therefore generate a
        // new season object from July and that will hopefully be suitable forever.
        // Cue a strange-timed world cup ruining this idea.
        internal static int StartYear = 1993;

        internal static int LatestSeasonStartYear(DateTime currentDate)
        {
            // From January to July the start year of the latest season was the previous year
            return currentDate.Year - (currentDate.Month < 7 ? 1 : 0);
        }

        /// <summary>
        /// Returns a list of all seasons for which there is data
        /// </summary>
        /// <returns></returns>
        public static List<Season> Get()
        {
            return GenerateSeasons(StartYear, LatestSeasonStartYear(DateTime.Now));
        }

        /// <summary>
        /// Returns an object representing the latest season
        /// </summary>
        /// <returns></returns>
        public static Season GetLatest()
        {
            return Get().First();
        }

        internal static List<Season> GenerateSeasons(int startYear, int latestSeasonStartYear)
        {
            var seasons = new List<Season>();
            var loopYear = startYear;

            do
            {
                seasons.Add(new Season(loopYear, loopYear + 1));

                loopYear += 1;
            } while (loopYear <= latestSeasonStartYear);

            return seasons.OrderByDescending(x => x.StartYear).ToList();
        }
    }
}
