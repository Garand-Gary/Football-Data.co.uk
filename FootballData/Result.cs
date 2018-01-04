using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    public class Result
    {
        private Match thisMatch;

        public League Division { get { return thisMatch.Division; } }
        public DateTime MatchDate { get { return thisMatch.MatchDate; } }
        public Team HomeTeam { get { return thisMatch.HomeTeam; } }
        public Team AwayTeam { get { return thisMatch.AwayTeam; } }

        public Score FullTimeScore { get { return thisMatch.FullTimeScore; } }
        public Outcome FullTimeResult { get { return thisMatch.FullTimeResult; } }

        public Score HalfTimeScore { get { return thisMatch.HalfTimeScore; } }
        public Outcome HalfTimeResult { get { return thisMatch.HalfTimeResult; } }

        public MatchOdds Odds { get { return thisMatch.Odds; } }
        public MatchStats Stats { get { return thisMatch.Stats; } }

        internal Result(Match match)
        {
            thisMatch = match;
        }
    }
}
