using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        int n;
        bool check;
        do
        {
            Console.Write("Please, enter integer n (1 < n < 100): ");
            int.TryParse(Console.ReadLine(), out n);
            check = (1 < n) && (n < 100);
        } while (!check);
        BigInteger numerator = 1;
        for (int i = (n + 1); i <= 2*n; i++)
        {
            numerator *= i;
        }
        BigInteger denominator = 1;
        for (int j = 1; j <= ( n + 1 ); j++)
        {
            denominator *= j;
        }
        BigInteger result = numerator / denominator;
        Console.WriteLine("{0:0}", result);
    }
}
