namespace _05.Mountains_Code_First
{
    using System.Data.Entity;

    public class MountainsMigrationStrategy : DropCreateDatabaseIfModelChanges<MountainsContext>
    {
        protected override void Seed(MountainsContext context)
        {
            var bulgaria = new Country { Code = "BG", Name = "Bulgaria" };
            var germany = new Country { Code = "DE", Name = "Germany" };
            context.Countries.Add(bulgaria);
            context.Countries.Add(germany);

            var rila = new Mountain { Name = "Rila", Country = bulgaria };
            var rhodopes = new Mountain { Name = "Rhodepes", Country = bulgaria };
            var pirin = new Mountain { Name = "Pirin", Country = bulgaria };
            context.Mountains.Add(rila);
            context.Mountains.Add(rhodopes);
            context.Mountains.Add(pirin);

            var musala = new Peak { Name = "Musala", Elevation = 2925, Mountain = rila };
            var malyovitsa = new Peak { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
            var vihren = new Peak { Name = "Vihren", Elevation = 2914, Mountain = pirin };
            context.Peaks.Add(musala);
            context.Peaks.Add(malyovitsa);
            context.Peaks.Add(vihren);
        }
    }
}
