using System.Collections.Generic;

namespace FootballData
{
    public class Betting
    {
        public List<MatchBet> MatchBets { get; set; }
        public MatchBet ClosingOdds { get; set; }

        public List<GoalsBet> GoalsBets { get; set; }
        public List<AsianHandicapBet> AsianHandicapBets { get; set; }
    }
}
