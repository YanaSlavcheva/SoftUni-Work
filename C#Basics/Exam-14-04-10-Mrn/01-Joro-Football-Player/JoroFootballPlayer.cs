using System;
class JoroFootballPlayer
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        int allWeekends = 52;
        double result = 0;

        int normalWeekends = allWeekends - h;
        result = 2 * normalWeekends / 3 + p / 2 + h;

        if (leap == "t")
        {
            result += 3;
        }
        Console.WriteLine("{0:F0}", result);
    }
}
