using System;
class NumbersNotDiv3And7
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            bool div3 = (i % 3 != 0);
            bool div7 = (i % 7 != 0);
            if (div3 && div7)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
