namespace FootballData.Entities
{
    /// <summary>
    /// A class that represents the Over/Under 2.5 Goals odds offered by a bookmaker
    /// </summary>
    public class GoalsBet
    {
        /// <summary>
        /// The bookmaker offering these odds
        /// </summary>
        public Bookmaker Bookmaker { get; set; }

        /// <summary>
        /// The odds offered to back over 2.5 goals in this match
        /// </summary>
        public decimal Over2_5 { get; set; }

        /// <summary>
        /// The odds offered to back under 2.5 goals in this match
        /// </summary>
        public decimal Under2_5 { get; set; }
    }
}
