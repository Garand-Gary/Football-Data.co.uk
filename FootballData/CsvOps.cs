using FootballData.Entities;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.IO;

namespace FootballData
{
    internal class CsvOps
    {
        internal static List<Match> GetMatchesFromCsv(Stream data)
        {
            data.Position = 0;
            var output = new List<Match>();

            using (var streamReader = new StreamReader(data))
            {
                using (var csv = new CsvReader(streamReader))
                {
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.BadDataFound = null;

                    // Register the class map, found within DataFileMap.cs
                    csv.Configuration.RegisterClassMap<MatchMap>();

                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Match>();

                        // We only want matches from leagues that are in the configuration
                        var league = Leagues.GetAll().FirstOrDefault(div => div.Id == record.Division.Id);

                        if (league != null)
                        {
                            // Can't figure out how to lookup and assign an object in ClassMap so will do it here
                            record.Division = league;

                            output.Add(record);
                        }
                    }

                    return output;
                }
            }
        }
    }
}
