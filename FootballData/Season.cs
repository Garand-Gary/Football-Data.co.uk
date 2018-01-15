using System;

namespace FootballData
{
    public class Season
    {
        public string Id { get; }
        public string Name { get; }
        public string ShortName { get; }
        public string LongName { get; }

        internal int StartYear { get; }

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
        }
    }
}
