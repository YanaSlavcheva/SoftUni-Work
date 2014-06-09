using System;
class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Fib(n);
    }

    private static void Fib(int n)
    {
        if (n == 0)
        {
            Console.WriteLine("1");
        }
        else if (n == 1)
        {
            Console.WriteLine("1");
        }
        else if (n == 2)
        {
            Console.WriteLine("2");
        }
        else
        {
            long num01 = 1;
            long num02 = 2;
            long numN = num01 + num02;
            for (int i = 3; i <= n; i++)
            {
                numN = num01 + num02;
                num01 = num02;
                num02 = numN;
            }
            Console.WriteLine(numN);
        }
    }
}
