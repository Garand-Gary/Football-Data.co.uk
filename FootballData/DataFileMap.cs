using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using FootballData.Entities;
using System.Collections.Generic;

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
            References<BettingMap>(x => x.Betting);
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
            var prefix = "H";

            Map(x => x.Name).Name("HomeTeam");
            Map(x => x.Stats).ConvertUsing(row =>
            {
                var list = new List<Statistic>();

                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Shots, prefix + "S", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.ShotsOnTarget, prefix + "ST", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.HitWoodwork, prefix + "HW", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Corners, prefix + "C", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.FoulsCommitted, prefix + "F", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Offsides, prefix + "O", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.YellowCards, prefix + "Y", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.RedCards, prefix + "R", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.BookingPoints, prefix + "BP", row));

                return list;
            });
        }
    }

    internal class AwayTeamMap : ClassMap<Team>
    {
        public AwayTeamMap()
        {
            var prefix = "A";

            Map(x => x.Name).Name("AwayTeam");
            Map(x => x.Stats).ConvertUsing(row =>
            {
                var list = new List<Statistic>();

                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Shots, prefix + "S", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.ShotsOnTarget, prefix + "ST", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.HitWoodwork, prefix + "HW", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Corners, prefix + "C", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.FoulsCommitted, prefix + "F", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.Offsides, prefix + "O", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.YellowCards, prefix + "Y", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.RedCards, prefix + "R", row));
                list.AddIfNotNull(MatchStatsHelper.GetStat(Statistic.StatType.BookingPoints, prefix + "BP", row));

                return list;
            });
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

    internal class BettingMap : ClassMap<Betting>
    {
        public BettingMap()
        {
            Map(x => x.MatchBets).ConvertUsing(row =>
            {
                var list = new List<MatchBet>();

                Bookmakers.Get().ForEach(x => list.AddIfNotNull(GetMatchBet(row, x)));

                return list;
            });

            Map(x => x.GoalsBets).ConvertUsing(row =>
            {
                var list = new List<GoalsBet>();

                Bookmakers.Get().ForEach(x => list.AddIfNotNull(GetGoalsBet(row, x)));

                return list;
            });

            Map(x => x.AsianHandicapBets).ConvertUsing(row =>
            {
                var list = new List<AsianHandicapBet>();

                Bookmakers.Get().ForEach(x => list.AddIfNotNull(GetAsianHandicapBet(row, x)));

                return list;
            });

            Map(x => x.ClosingOdds).ConvertUsing(row =>
            {
                return GetMatchBet(row, new Bookmaker { Id = "PSC", Name = "Pinnacle Sports Closing" });
            });
        }

        private MatchBet GetMatchBet(IReaderRow row, Bookmaker bm)
        {
            try
            {
                var home = GetValue(row, bm.Id + "H");
                var draw = GetValue(row, bm.Id + "D");
                var away = GetValue(row, bm.Id + "A");

                // We will assume if we have home odds we have all odds
                if (home != null)
                {
                    return new MatchBet
                    {
                        Bookmaker = bm,
                        Home = (decimal)home,
                        Draw = (decimal)draw,
                        Away = (decimal)away
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private GoalsBet GetGoalsBet(IReaderRow row, Bookmaker bm)
        {
            try
            {
                var over = GetValue(row, bm.Id + ">2.5");
                var under = GetValue(row, bm.Id + "<2.5");

                // If we have over we will assume we are good to go
                if (over != null)
                {
                    return new GoalsBet
                    {
                        Bookmaker = bm,
                        Over2_5 = (decimal)over,
                        Under2_5 = (decimal)under
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private AsianHandicapBet GetAsianHandicapBet(IReaderRow row, Bookmaker bm)
        {
            try
            {
                var home = GetValue(row, bm.Id + "AHH");
                var away = GetValue(row, bm.Id + "AHA");
                var handicap = GetValue(row, bm.Id + "AH");

                // Assume if we have the home we have the lot
                if (home != null)
                {
                    return new AsianHandicapBet
                    {
                        Bookmaker = bm,
                        Home = (decimal)home,
                        Away = (decimal)away,
                        HomeTeamHandicap = (decimal)handicap
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private decimal? GetValue(IReaderRow row, string key)
        {
            try
            {
                return row.GetField<decimal?>(key);
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

    // Helper class for dealing with the match stats
    internal static class MatchStatsHelper
    {
        internal static Statistic GetStat(Statistic.StatType type, string csvFieldName, IReaderRow row)
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
}
