namespace _03.Export_Monasteries_as_XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using EF_Mappings;

    public class ExportMonasteriesAsXml
    {
        public static void Main(string[] args)
        {
            var context = new GeographyEntities();

            // Test access to monasteries
            //var monasteries = context.Monasteries;
            //foreach (var monastery in monasteries)
            //{
            //    Console.WriteLine(monastery.Name);
            //}

            var countriesQuery =
                context.Countries
                .OrderBy(c => c.CountryName)
                .Where(c => c.Monasteries.Any())
                .Select(
                    c => new
                        {
                            c.CountryName,
                            Monasteries = c.Monasteries
                                .OrderBy(m => m.Name)
                                .Select(m => m.Name)
                        })
                .ToList();

            // Test the query
            //foreach (var country in countriesQuery)
            //{
            //    Console.WriteLine(country.CountryName + ": " + string.Join(", ", country.Monasteries));
            //}
            //Console.WriteLine();

            // Export to XML
            var xmlMonasteries = new XElement("monasteries");
            foreach (var country in countriesQuery)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));
                xmlMonasteries.Add(xmlCountry);

                foreach (var monastery in country.Monasteries)
                {
                    var xmlMonastery = new XElement("monastery", monastery);
                    xmlCountry.Add(xmlMonastery);
                }
            }

            // Test the xml content on the console
            //Console.WriteLine(xmlMonasteries);
            //Console.WriteLine();

            var xmlDoc = new XDocument(xmlMonasteries);
            var filePathName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Monasteries.xml";
            xmlDoc.Save(filePathName);
        }
    }
}
