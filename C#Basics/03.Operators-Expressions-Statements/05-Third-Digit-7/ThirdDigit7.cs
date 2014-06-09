using System;
class ThirdDigit7
{
    static void Main()
    {
        Console.WriteLine("Please, enter an integer:");
        int number = int.Parse(Console.ReadLine());
        var thirdDigit = (number / 100) % 10;
        if (thirdDigit == 7)
        {
            Console.WriteLine("The third digit from right-to-left of the integer You entered is 7.");
        }
        else
        {
            Console.WriteLine("The third digit from right-to-left of the integer You entered is NOT 7.");
        }
    }
}
