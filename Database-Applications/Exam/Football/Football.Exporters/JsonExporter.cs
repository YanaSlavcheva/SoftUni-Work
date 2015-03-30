namespace Football.Exporters
{
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;

    using Formatting = Newtonsoft.Json.Formatting;

    public class JsonExporter : IExporter
    {
        public void Export(string path, IEnumerable<object> query)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, query);
            }
        }
    }
}
