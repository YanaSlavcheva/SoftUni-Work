using System;
using System.Linq;

class Sum5Numbers
{
    static void Main()
    {
        Console.Write("Please, enter 5 numbers, seperated by space: ");
        string[] numbers = Console.ReadLine().Split(' ');
        double[] numbersInDouble = new Double[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbersInDouble[i] = double.Parse(numbers[i]);
        }
        var sum = numbersInDouble.Sum();
        Console.WriteLine("The sum of the numbers is {0}.", sum);
    }
}
