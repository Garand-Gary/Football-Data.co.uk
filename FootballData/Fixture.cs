using System;

namespace FootballData
{
    public class Fixture
    {
        private Match thisMatch;

        public League Division { get { return thisMatch.Division; } }
        public DateTime MatchDate { get { return thisMatch.MatchDate; } }
        public Team HomeTeam { get { return thisMatch.HomeTeam; } }
        public Team AwayTeam { get { return thisMatch.AwayTeam; } }
        public Betting Odds { get { return thisMatch.Betting; } }

        internal Fixture(Match match)
        {
            thisMatch = match;
        }
    }
}
