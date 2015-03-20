namespace _04.Import_Rivers_From_XML
{
    using System;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using EF_Mappings;

    public class ImportRiversFromXml
    {
        public static void Main(string[] args)
        {
            var context = new GeographyEntities();

            // Parse the test file rivers.xml
            var xmlDoc = XDocument.Load(@"..\..\rivers.xml");

            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");

            foreach (var riverNode in riverNodes)
            {
                // mandatory
                string riverName = riverNode.Element("name").Value;
                int riverLength = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;

                // optional
                int? riverDrainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    riverDrainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? riverAverageDischarge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    riverAverageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                // Create object for current River
                var river = new Rivers()
                {
                    RiverName = riverName,
                    Length = riverLength,
                    DrainageArea = riverDrainageArea,
                    AverageDischarge = riverAverageDischarge,
                    Outflow = riverOutflow
                };

                // Add the countries for the rivers
                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countryNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                // Add the rivers to the DB
                context.Rivers.Add(river);
                context.SaveChanges();
            }
        }
    }
}
