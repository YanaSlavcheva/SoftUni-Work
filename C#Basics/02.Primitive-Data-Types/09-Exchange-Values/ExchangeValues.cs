using System;
class ExchangeValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Initially: ");
        Console.WriteLine("a = "+ a);
        Console.WriteLine("b = " + b);
        int temp;
        temp = a;
        a = b;
        b = temp;
        Console.WriteLine("After exchange: ");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
    }
}
