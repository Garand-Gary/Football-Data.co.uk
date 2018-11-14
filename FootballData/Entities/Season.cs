using System;

namespace FootballData.Entities
{
    /// <summary>
    /// A class representing a season that football-data.co.uk holds data for
    /// </summary>
    public class Season
    {
        /// <summary>
        /// The four digit ID for this season, which is found in the URL for the data
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The common name for this season, e.g. 2017/18
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The short name for this season, e.g. 17/18
        /// </summary>
        public string ShortName { get; }

        /// <summary>
        /// The long name for this season, e.g. 2017/2018
        /// </summary>
        public string LongName { get; }

        /// <summary>
        /// The year during which this season started
        /// </summary>
        public int StartYear { get; }

        /// <summary>
        /// The year during which this season ended
        /// </summary>
        public int EndYear { get; }

        internal Season(int startYear, int endYear)
        {
            // Things get easier with DateTimes
            var startDate = new DateTime(startYear, 01, 01);
            var endDate = new DateTime(endYear, 01, 01);

            Id = startDate.ToString("yy") + endDate.ToString("yy");

            Name = String.Format("{0}/{1}", startDate.ToString("yyyy"), endDate.ToString("yy"));
            ShortName = String.Format("{0}/{1}", startDate.ToString("yy"), endDate.ToString("yy"));
            LongName = String.Format("{0}/{1}", startDate.ToString("yyyy"), endDate.ToString("yyyy"));

            StartYear = startYear;
            EndYear = endYear;
        }
    }
}
