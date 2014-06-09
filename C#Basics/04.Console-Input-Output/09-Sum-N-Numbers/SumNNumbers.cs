using System;
using System.Linq;
class SumNNumbers
{
    static void Main()
    {
        Console.Write("Please, enter number n: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        var sum = numbers.Sum();
        Console.WriteLine("The sum of the numbers is {0}.", sum);
    }
}
