namespace FootballData
{
    /// <summary>
    /// A class that represents the Home/Draw/Away (1X2) odds offered by a bookmaker
    /// </summary>
    public class MatchBet
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
        /// The odds offered to back the draw
        /// </summary>
        public decimal Draw { get; set; }

        /// <summary>
        /// The odds offered to back the away team winning
        /// </summary>
        public decimal Away { get; set; }
    }
}
