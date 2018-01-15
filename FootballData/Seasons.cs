using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
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

        internal static int LatestSeasonStartYear
        {
            get
            {
                // var now = new DateTime(2018, 07, 01);
                var now = DateTime.Now;

                // From January to July the start year of the latest season was the previous year
                return now.Year - (now.Month < 7 ? 1 : 0);
            }
        }

        public static List<Season> Get()
        {
            var seasons = new List<Season>();
            var loopYear = StartYear;

            do
            {
                seasons.Add(new Season(loopYear, loopYear + 1));

                loopYear += 1;
            } while (loopYear <= LatestSeasonStartYear);

            return seasons.OrderByDescending(x => x.StartYear).ToList();
        }

        public static Season GetLatest()
        {
            return Get().First();
        }
    }
}
