using System;
class BonusScore
{
    static void Main()
    {
        Console.Write("Please, enter integer n, (1 < n < 9): ");
        int n = int.Parse(Console.ReadLine());
        if ((1 <= n) && (n <= 3))
        {
            n *= 10;
            Console.WriteLine("result is {0}", n);
        }
        else if ((4 <= n) && (n <= 6))
        {
            n *= 100;
            Console.WriteLine("result is {0}", n);
        }
        else if ((7 <= n) && (n <= 9))
        {
            n *= 1000;
            Console.WriteLine("result is {0}", n);
        }
        else if ((n == 0) || (n > 9))
        {
            Console.WriteLine("invalid score");
        }
    }
}
