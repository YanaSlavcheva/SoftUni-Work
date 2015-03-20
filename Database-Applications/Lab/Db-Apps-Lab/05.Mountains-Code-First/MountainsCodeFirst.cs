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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MountainsContext>());

            Country c = new Country(){Code = "AB", Name = "Ababab"};
            Mountain m = new Mountain(){Name = "Mountain"};
            m.Peaks.Add(new Peak(){Name = "PeakOne"});
            m.Peaks.Add(new Peak(){Name = "PeakTwo"});
            c.Mountains.Add(m);

            db.Countries.Add(c);
            db.SaveChanges();
        }
    }
}
