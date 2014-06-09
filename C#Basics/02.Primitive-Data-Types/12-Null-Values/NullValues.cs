using System;
class NullValues
{
    static void Main()
    {
        int? nullInt = null;
        Console.WriteLine(nullInt);
        double? nullDouble = null;
        Console.WriteLine(nullDouble);
        nullInt = 3;
        Console.WriteLine(nullInt.GetValueOrDefault());
        nullDouble = 8;
        Console.WriteLine(nullDouble.GetValueOrDefault());
    }
}
