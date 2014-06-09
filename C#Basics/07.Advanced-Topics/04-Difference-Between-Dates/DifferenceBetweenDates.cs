using System;
class DifferenceBetweenDates
{
    static void Main()
    {
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        //Console.WriteLine(firstDate);
        //Console.WriteLine(secondDate);

        TimeSpan daysInBetween = secondDate - firstDate;
        bool check = (firstDate <= secondDate);
        if (check)
        {
            Console.WriteLine("{0:%d}", daysInBetween);
        }
        else
        {
            Console.WriteLine("-{0:%d}", daysInBetween);
        }
        

    }
}

