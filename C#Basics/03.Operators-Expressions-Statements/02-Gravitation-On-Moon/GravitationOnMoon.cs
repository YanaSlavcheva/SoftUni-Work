using System;
class GravitationOnMoon
{
    static void Main()
    {
        Console.WriteLine("Please, enter a person's weight in kilograms:");
        double weightEarth = double.Parse(Console.ReadLine());
        double weightMoon = (weightEarth * 0.17);
        double weightMoonRound = Math.Round(weightMoon, 3);
        Console.WriteLine("This person would weight " + weightMoonRound + "kg on the Moon.");
    }
}
