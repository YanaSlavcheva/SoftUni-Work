using System;
using System.Numerics;
class FactorialNandK2
{
    static void Main()
    {
        int n;
        int k;
        bool check;
        do
        {
            Console.Write("Please, enter integers n and k (1 < k < n < 100), seperated by space: ");
            string integersPrimal = Console.ReadLine();
            string[] integers = integersPrimal.Split(' ');
            int.TryParse(integers[0], out n);
            int.TryParse(integers[1], out k);
            check = (1 < k) && (k < n) && (n < 100);
        } while (!check);
        BigInteger numerator = 1;
        for (int i = (k + 1); i <= n; i++)
        {
            numerator *= i;
        }
        BigInteger factorialDevider = 1;
        for (int j = 1; j <= ( n - k ); j++)
        {
            factorialDevider *= j;
        }
        BigInteger result = numerator / factorialDevider;
        Console.WriteLine("{0}", result);
    }
}
