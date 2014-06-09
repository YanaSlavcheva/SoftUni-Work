using System;
class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Please, enter number n: ");
        int n = int.Parse(Console.ReadLine());
        int f1 = 0;
        int f2 = 1;
        int f3;
        Console.Write("{0} {1} ", f1, f2);
        for (int i = 0; i < (n - 2); i++)
        {
            f3 = f1 + f2;
            Console.Write("{0} ", f3);
            f1 = f2;
            f2 = f3;
        }
    }
}
