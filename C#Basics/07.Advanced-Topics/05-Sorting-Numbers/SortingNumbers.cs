using System;
using System.Linq;
class SortingNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arrayNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            arrayNumbers[i] = int.Parse(Console.ReadLine());
        }
        int[] sortedNumbers = arrayNumbers.OrderBy(i => i).ToArray();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(sortedNumbers[i]);
        }
    }
}
