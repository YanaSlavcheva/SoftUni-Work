namespace _02.Export_Rivers_as_JSON
{
    using System;
    using System.IO;
    using System.Linq;

    using EF_Mappings;

    using Newtonsoft.Json;

    public class ExportRiversAsJson
    {
        public static void Main(string[] args)
        {
            var context = new GeographyEntities();

            // Test the link to DB
            //var rivers = context.Rivers;

            //foreach (var river in rivers)
            //{
            //    Console.WriteLine(river.RiverName);
            //}


            var riversNeededInfo = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r =>
                new
                {
                    Name = r.RiverName,
                    Length = r.Length,
                    Countries = r.Countries
                                .OrderBy(c => c.CountryName)
                                .Select(c => c.CountryName)
                }).ToList();

            // Test the query in the console
            //foreach (var river in riversNeededInfo)
            //{
            //    Console.WriteLine("River: " + river.Name + ", " + river.Length + "m");
            //    var countries = string.Join(", ", Array.ConvertAll(river.Countries.ToArray(), i => i.ToString()));
            //    Console.WriteLine("\tCountries: {0}", countries);
            //    Console.WriteLine();
            //}

            // Export to JSON
            var serializer = new JsonSerializer();
            var filePathName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Rivers.json";

            using (var sw = new StreamWriter(filePathName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, riversNeededInfo);
            }
        }
    }
}
