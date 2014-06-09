using System;
class Numbers1ToN
{
    static void Main()
    {
        Console.Write("Please, enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
