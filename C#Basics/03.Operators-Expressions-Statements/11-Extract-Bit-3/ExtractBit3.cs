using System;
class ExtractBit3
{
    static void Main()
    {
        uint n;
        bool check;
        do
        {
            Console.WriteLine("Please, enter unsigned integer \"n\".");
            check = uint.TryParse(Console.ReadLine(), out n);
        }
        while (!check);
        uint mask = (1 << 3);
        uint mergeMaskN = (n & mask);
        uint bit3 = (mergeMaskN >> 3);
        Console.WriteLine("The value of the bit #3 of \"n\" is {0}.", bit3);
    }
}
