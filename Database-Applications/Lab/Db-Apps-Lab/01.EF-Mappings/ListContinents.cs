namespace EF_Mappings
{
    using System;

    public class ListContinents
    {
        public static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var continents = context.Continents;

            foreach (var continent in continents)
            {
                Console.WriteLine(continent.ContinentName);
            }

            Console.WriteLine();
        }
    }
}
