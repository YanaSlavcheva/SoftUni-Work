namespace Geography.Client
{
    using System;
    using System.Linq;

    using Geography.Data;
    using Geography.DataTransferObjects;
    using Geography.Exporters;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            // Test link to the Db
            var context = new GeographyEntities();
            //var continentsQuery = context.Continents.Select(c => c.ContinentName);

            //foreach (var continent in continentsQuery)
            //{
            //    Console.WriteLine(continent);
            //}

            // Export Rivers to JSON
            var riversQuery =
               context.Rivers
               .OrderByDescending(r => r.Length)
               .Select(
                   r =>
                   new RiversDto
                   {
                       RiverName = r.RiverName,
                       RiverLength = r.Length,
                       Countries = r.Countries
                           .OrderBy(c => c.CountryName)
                           .Select(c => c.CountryName)
                   }).ToList();
            var filePathNameJson = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Rivers.json";

            JsonExporter.Export(filePathNameJson, riversQuery);

            // Export Monasteries by Country as XML
            var countriesWMonasteriesQuery = context.Countries
                .OrderBy(c => c.CountryName)
                .Where(c => c.Monasteries.Any())
                .Select(c => new CountriesDto()
                                                                               {
                                                                                   CountryName = c.CountryName,
                                                                                   Monasteries = c.Monasteries.Select(m => m.Name)
                                                                               }).ToList();

            var filePathNameXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Monasteries.xml";

            XmlExporter.Export(filePathNameXml, countriesWMonasteriesQuery);
        }
    }
}
