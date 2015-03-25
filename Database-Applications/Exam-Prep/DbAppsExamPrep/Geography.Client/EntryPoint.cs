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
            var filePathName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Rivers.json";

            JsonExporter.Export(filePathName, riversQuery);
        }
    }
}
