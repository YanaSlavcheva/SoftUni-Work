using System;
class BiggestNumber5
{
    static void Main()
    {
        Console.WriteLine("Please, enter 5 numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());
        int biggestNumber = a;
        if ((b > a))
        {
            biggestNumber = b;
        }
        if ((c > a) && (c > b))
        {
            biggestNumber = c;
        }
        if ((d > a) && (d > b) && (d > c))
        {
            biggestNumber = d;
        }
        if ((e > a) && (e > b) && (e > c) && (e > d))
        {
            biggestNumber = e;
        }
        Console.WriteLine("The biggest number is {0}.", biggestNumber);
    }
}
