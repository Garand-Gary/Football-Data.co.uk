using System.Collections.Generic;

namespace FootballData
{
    /// <summary>
    /// Contains odds for different types of bets and from different bookmakers
    /// </summary>
    public class Betting
    {
        /// <summary>
        /// A list of 1X2 betting odds from various bookmakers
        /// </summary>
        public List<MatchBet> MatchBets { get; set; }

        /// <summary>
        /// The Pinnacle closing odds for the match
        /// </summary>
        public MatchBet ClosingOdds { get; set; }

        /// <summary>
        /// A list of Over/Under 2.5 goals odds from various bookmakers
        /// </summary>
        public List<GoalsBet> GoalsBets { get; set; }

        /// <summary>
        /// A list of Asian Handicap odds from various bookmakers
        /// </summary>
        public List<AsianHandicapBet> AsianHandicapBets { get; set; }
    }
}
