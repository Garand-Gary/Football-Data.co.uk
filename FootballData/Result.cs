using System;

namespace FootballData
{
    public class Result
    {
        private Match thisMatch;

        public League Division { get { return thisMatch.Division; } }
        public DateTime MatchDate { get { return thisMatch.MatchDate; } }
        public Team HomeTeam { get { return thisMatch.HomeTeam; } }
        public Team AwayTeam { get { return thisMatch.AwayTeam; } }

        public Referee Referee { get { return thisMatch.Referee; } }

        public Score FullTimeScore { get { return thisMatch.FullTimeScore; } }
        public Outcome FullTimeResult { get { return thisMatch.FullTimeResult; } }

        public Score HalfTimeScore { get { return thisMatch.HalfTimeScore; } }
        public Outcome HalfTimeResult { get { return thisMatch.HalfTimeResult; } }

        public Betting Odds { get { return thisMatch.Odds; } }

        internal Result(Match match)
        {
            thisMatch = match;
        }
    }
}
