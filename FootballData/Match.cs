using System;

namespace FootballData
{
    internal class Match
    {
        public League Division { get; set; }
        public DateTime MatchDate { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public Referee Referee { get; set; }

        public Score FullTimeScore { get; set; }
        public Outcome FullTimeResult { get { return GetOutcome(FullTimeScore); } }

        public Score HalfTimeScore { get; set; }
        public Outcome HalfTimeResult { get { return GetOutcome(HalfTimeScore); } }

        public Betting Betting { get; set; }

        private Outcome GetOutcome(Score score)
        {
            var goalDelta = score.HomeGoals - score.AwayGoals;

            if (goalDelta > 0) { return Outcome.Home; }
            if (goalDelta < 0) { return Outcome.Away; }

            return Outcome.Draw;
        }
    }

    public enum Outcome
    {
        Draw,
        Home,
        Away
    }
}