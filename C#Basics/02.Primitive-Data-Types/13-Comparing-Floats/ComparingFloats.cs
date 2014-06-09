using System;
class ComparingFloats
{
    static void Main()
    {
        Console.WriteLine("Please, enter the first floating-point number to compare: ");
        float firstNumber = float.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the second floating-point number to compare: ");
        float secondNumber = float.Parse(Console.ReadLine());
        double difference = Math.Abs(firstNumber - secondNumber);
        double differenceRound = Math.Round(difference, 7);
        if (differenceRound < 0.000001)
        {
            Console.WriteLine("The two numbers You entered are equal.");
        }
        else
        {
            Console.WriteLine("The two numbers You entered are NOT equal.");
        }
    }
}
