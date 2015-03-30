namespace Football.Client
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Football.Data;
    using Football.DataTransferObjects;
    using Football.Exporters;
    using Football.Importers;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var context = new FootballEntities();

            // Problem 1.Entity Framework Mappings (Database First)
            //var teamsQuery = context.Teams.Select(t => t.TeamName);
            //foreach (var team in teamsQuery)
            //{
            //    Console.WriteLine(team);
            //}

            // Problem 2.Export the Leagues and Teams as JSON
            //var leaguesQuery =
            //    context.Leagues.OrderBy(l => l.LeagueName)
            //        .Select(
            //            l =>
            //            new LeagueDto
            //                {
            //                    LeagueName = l.LeagueName,
            //                    Teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
            //                })
            //        .ToList();

            //const string FilePathNameJson = "../../leagues-and-teams.json";

            //var jsonExporter = new JsonExporter();
            //jsonExporter.Export(FilePathNameJson, leaguesQuery);

            // Problem 3.Export International Matches as XML
            //var internationalMatchesQuery = context.InternationalMatches
            //    .OrderBy(im => im.MatchDate)
            //    .ThenBy(im => im.Countries)
            //    .ThenBy(im => im.Countries1)
            //    .Select(im => new InternationalMatchesDto()
            //    {
            //        HomeCountry = im.Countries1.CountryName,
            //        AwayCountry = im.Countries.CountryName,
            //        MatchDate = im.MatchDate.ToString(),
            //        Score = im.HomeGoals.ToString() + "-" + im.AwayGoals.ToString(),
            //        League = im.Leagues.LeagueName,
            //        HomeCountryCode = im.HomeCountryCode,
            //        AwayCountryCode = im.AwayCountryCode
            //    }).ToList();

            //const string FilePathNameXml = "../../international-matches.xml ";

            //var xmlExporter = new XmlExporter();
            //xmlExporter.Export(FilePathNameXml, internationalMatchesQuery);

            // Problem 4.Import Leagues and Teams from XML
            // Import rivers from Xml file
            var xmlImporter = new XmlImporter();
            var xmlDoc = XDocument.Load(@"..\..\leagues-and-teams.xml ");
            xmlImporter.Import(xmlDoc, context);
        }
    }
}
