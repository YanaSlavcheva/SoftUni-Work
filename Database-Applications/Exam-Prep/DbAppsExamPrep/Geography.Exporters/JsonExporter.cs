namespace Geography.Exporters
{
    using System.Collections.Generic;
    using System.IO;

    using Geography.DataTransferObjects;

    using Newtonsoft.Json;

    public class JsonExporter
    {
        public static void Export(string fileNameLocation, List<RiversDto> riversQuery)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(fileNameLocation))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, riversQuery);
            }
        }
    }
}
