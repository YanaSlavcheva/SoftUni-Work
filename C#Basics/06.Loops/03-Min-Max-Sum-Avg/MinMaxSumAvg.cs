using System;
class MinMaxSumAvg
{
    static void Main()
    {
        Console.Write("Please, enter integer n= ");
        int n = int.Parse(Console.ReadLine());
        int[] allNumbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            allNumbers[i] = int.Parse(Console.ReadLine());
        }
        int minNumber = allNumbers[0];
        int maxNumber = allNumbers[0];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            bool comparisonMin = (allNumbers[i] < minNumber);
            if (comparisonMin)
            {
                minNumber = allNumbers[i];
            }
            bool comparisonMax = (allNumbers[i] > maxNumber);
            if (comparisonMax)
            {
                maxNumber = allNumbers[i];
            }
            sum += allNumbers[i];
        }
        double sumDouble = (double)sum;
        double avg = sumDouble / n;
        Console.WriteLine("The minimal number is {0}.", minNumber);
        Console.WriteLine("The maximal number is {0}.", maxNumber);
        Console.WriteLine("The sum is {0}.", sum);
        Console.WriteLine("The average is {0:0.00}", avg);
    }
}
