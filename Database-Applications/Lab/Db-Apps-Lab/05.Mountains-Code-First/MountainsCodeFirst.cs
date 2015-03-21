namespace _05.Mountains_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainsCodeFirst
    {
        public static void Main(string[] args)
        {
            var db = new MountainsContext();
            Database.SetInitializer(new MountainsMigrationStrategy());

            var countriesQuery =
                db.Countries.Select(
                    c => new { CountryName = c.Name, Mountains = c.Mountains.Select(m => new { m.Name, m.Peaks }) });

            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country: " + country.CountryName);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("\tMountain: " + mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} => {1}", peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}
