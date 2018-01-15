namespace FootballData
{
    public class Statistic
    {
        public StatType Type { get; set; }
        public int? Value { get; set; }

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
