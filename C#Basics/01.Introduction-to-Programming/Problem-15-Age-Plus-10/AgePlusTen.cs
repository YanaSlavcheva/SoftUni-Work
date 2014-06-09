using System;
class AgePlusTen
{
    static void Main()
    {
        Console.WriteLine("Please, enter Your age:");
        int currentAge = int.Parse(Console.ReadLine());
        int afterTenYears = 10 + currentAge;
        Console.WriteLine("After ten years You will be {0} years old.", afterTenYears);
    }
}
