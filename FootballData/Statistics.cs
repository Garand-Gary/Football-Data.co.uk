using System.Collections.Generic;

namespace FootballData
{
    public class Statistics
    {
        public List<Statistic> List { get; set; }

        public enum StatType
        {
            Shots,
            ShotsOnTarget,
            HitWoodwork,
            Corners,
            FoulsCommitted,
            Offsides,
            YellowCards,
            RedCards,
            BookingPoints
        }
    }
}
