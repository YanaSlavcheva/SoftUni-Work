using System;
class Numbers1N
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ",i);
        }
    }
}
