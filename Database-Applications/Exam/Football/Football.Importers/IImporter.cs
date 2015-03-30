namespace Football.Importers
{
    using System.Xml.Linq;

    using Football.Data;

    public interface IImporter
    {
        void Import(XDocument file, FootballEntities context);
    }
}
