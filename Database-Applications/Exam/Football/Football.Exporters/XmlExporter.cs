namespace Football.Exporters
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Football.DataTransferObjects;

    public class XmlExporter : IExporter
    {
        public void Export(string path, IEnumerable<object> query)
        {
            var xmlMatches = new XElement("matches");
            var matchesQuery = query as IEnumerable<InternationalMatchesDto>;

            if (matchesQuery != null)
            {
                foreach (var match in matchesQuery)
                {
                    var xmlMatch = new XElement("match");

                    var xmlHomeCountry = new XElement("home-country", match.HomeCountry);
                    xmlHomeCountry.Add(new XAttribute("code", match.HomeCountryCode));
                    xmlMatch.Add(xmlHomeCountry);
                    var xmlAwayCountry = new XElement("away-country", match.AwayCountry);
                    xmlAwayCountry.Add(new XAttribute("code", match.AwayCountryCode));
                    xmlMatch.Add(xmlAwayCountry);
                    if (match.League != null)
                    {
                        var xmlLeague = new XElement("league", match.League);
                        xmlMatch.Add(xmlLeague);
                    }

                    if (match.Score != "-")
                    {
                        var xmlScore = new XElement("score", match.Score);
                        xmlMatch.Add(xmlScore);
                    }
           
                    if (match.MatchDate != string.Empty)
                    {
                        string date = match.MatchDate.Substring(0, 11);
                        string time = match.MatchDate.Substring(12, match.MatchDate.Length - 12);

                        if (!time.Equals("12:00AM"))
                        {
                            xmlMatch.Add(new XAttribute("date-time", match.MatchDate));
                        }
                        else
                        {
                            xmlMatch.Add(new XAttribute("date", date));
                        }
                    }           
                    xmlMatches.Add(xmlMatch);
                }
            }

            var xmlDoc = new XDocument(xmlMatches);
            xmlDoc.Save(path);
        }
    }
}
