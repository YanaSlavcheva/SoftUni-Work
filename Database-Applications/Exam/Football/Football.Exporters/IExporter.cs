namespace Football.Exporters
{
    using System.Collections.Generic;

    public interface IExporter
    {
        void Export(string path, IEnumerable<object> query);
    }
}
