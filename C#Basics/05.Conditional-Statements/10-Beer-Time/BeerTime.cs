using System;
using System.Globalization;
class BeerTime
{
    static void Main()
    {
        //string input = "00:59 PM";
        Console.Write("Enter time (hh:mm tt - for example 08:00 AM): ");
        string input = Console.ReadLine();
        DateTime time = DateTime.Now;
        try
        {
            DateTime.TryParseExact(input, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out time);
        }
        catch (Exception)
        {
            Console.WriteLine("invalid time");
        }
        //Console.WriteLine("{0}", time);
        string startBeer = "01:00 PM";
        DateTime startBeerTime = DateTime.Now;
        DateTime.TryParseExact(startBeer, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out startBeerTime);
        //Console.WriteLine("{0}", startBeerTime);
        string endBeer = "03:00 AM";
        DateTime endBeerTime = DateTime.Now;
        DateTime.TryParseExact(endBeer, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out endBeerTime);
        //Console.WriteLine("{0}", endBeerTime);
        if ((time < endBeerTime) || (time > startBeerTime))
        {
            Console.WriteLine("beer time");
        }
        else
        {
            Console.WriteLine("non-beer time");
        }
    }
}
