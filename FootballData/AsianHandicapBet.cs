namespace FootballData
{
    /// <summary>
    /// A class that represents the Asian Handicap odds offered by a bookmaker
    /// </summary>
    public class AsianHandicapBet
    {
        /// <summary>
        /// The bookmaker offering these odds
        /// </summary>
        public Bookmaker Bookmaker { get; set; }

        /// <summary>
        /// The odds offered to back the home team winning
        /// </summary>
        public decimal Home { get; set; }

        /// <summary>
        /// The odds offered to back the away team winning
        /// </summary>
        public decimal Away { get; set; }

        /// <summary>
        /// The handicap for this bet as it applies to the home team
        /// </summary>
        public decimal HomeTeamHandicap { get; set; }
    }
}
