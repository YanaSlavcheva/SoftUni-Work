using System;
class ExchangeIfGreater
{
    static void Main()
    {
        Console.WriteLine("Please, write two integers a and b: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        Console.WriteLine("{0} {1}", a, b);
    }
}
