using System.Linq;
using CsvHelper.Configuration;
using System.Collections.Generic;
using CsvHelper;

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
            References<HomeTeamStatsMap>(x => x.Stats);
        }
    }

    internal class AwayTeamMap : ClassMap<Team>
    {
        public AwayTeamMap()
        {
            Map(x => x.Name).Name("AwayTeam");
            References<AwayTeamStatsMap>(x => x.Stats);
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

    internal class HomeTeamStatsMap : StatsMap
    {
        public HomeTeamStatsMap() : base("H") { }
    }

    internal class AwayTeamStatsMap : StatsMap
    {
        public AwayTeamStatsMap() : base("A") { }
    }

    internal class StatsMap : ClassMap<Statistics>
    {
        public StatsMap(string prefix)
        {
            Map(x => x.List).ConvertUsing(row =>
            {
                var list = new List<Statistic>();

                list.AddIfNotNull(GetStat(Statistic.StatType.Shots, prefix + "S", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.ShotsOnTarget, prefix + "ST", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.HitWoodwork, prefix + "HW", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.Corners, prefix + "C", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.FoulsCommitted, prefix + "F", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.Offsides, prefix + "O", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.YellowCards, prefix + "Y", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.RedCards, prefix + "R", row));
                list.AddIfNotNull(GetStat(Statistic.StatType.BookingPoints, prefix + "BP", row));

                return list;
            }
            );
        }

        private Statistic GetStat(Statistic.StatType type, string csvFieldName, IReaderRow row)
        {
            try
            {
                var value = row.GetField<int?>(csvFieldName);
                if (value != null) { return new Statistic { Type = type, Value = value }; }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }

    // Extension method to make adding statistics less of a burden. For some lower leagues
    // we can expect the stats to be incomplete and therefore missing from the file
    // E.g. Scottish lower divisions only have the scores
    internal static class ListExtensions
    {
        internal static void AddIfNotNull<T>(this List<T> list, T item)
        {
            if (item != null) { list.Add(item); }
        }
    }
}
