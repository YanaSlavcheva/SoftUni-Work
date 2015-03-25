using System;
using System.Collections.Generic;
using System.Linq;
namespace Geography.Exporters
{
    using System.Xml.Linq;

    using Geography.DataTransferObjects;

    public class XmlExporter
    {
        public static void Export(string fileNameLocation, List<CountriesDto> countriesQuery)
        {
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

            var xmlDoc = new XDocument(xmlMonasteries);
            xmlDoc.Save(fileNameLocation);
        }
    }
}
