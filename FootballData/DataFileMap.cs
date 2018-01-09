using System.Linq;
using CsvHelper.Configuration;

namespace FootballData
{
    internal class MatchMap : ClassMap<Match>
    {
        public MatchMap()
        {
            Map(x => x.MatchDate).Name("Date");
            References<LeagueMap>(x => x.Division);
            References<HomeTeamMap>(x => x.HomeTeam);
            References<AwayTeamMap>(x => x.AwayTeam);
            References<RefereeMap>(x => x.Referee);
            References<FullTimeScoreMap>(x => x.FullTimeScore);
            References<HalfTimeScoreMap>(x => x.HalfTimeScore);
        }
    }

    internal class LeagueMap : ClassMap<League>
    {
        public LeagueMap()
        {
            Map(x => x.Id).Name("Div");
        }
    }

    internal class HomeTeamMap : ClassMap<Team>
    {
        public HomeTeamMap()
        {
            Map(x => x.Name).Name("HomeTeam");
        }
    }

    internal class AwayTeamMap : ClassMap<Team>
    {
        public AwayTeamMap()
        {
            Map(x => x.Name).Name("AwayTeam");
        }
    }

    internal class RefereeMap : ClassMap<Referee>
    {
        public RefereeMap()
        {
            Map(x => x.Name).Name("Referee");
        }
    }

    internal class FullTimeScoreMap : ClassMap<Score>
    {
        public FullTimeScoreMap()
        {
            Map(x => x.HomeGoals).Name("FTHG").Default(0);
            Map(x => x.AwayGoals).Name("FTAG").Default(0);
        }
    }

    internal class HalfTimeScoreMap : ClassMap<Score>
    {
        public HalfTimeScoreMap()
        {
            Map(x => x.HomeGoals).Name("HTHG").Default(0);
            Map(x => x.AwayGoals).Name("HTAG").Default(0);
        }
    }
}
