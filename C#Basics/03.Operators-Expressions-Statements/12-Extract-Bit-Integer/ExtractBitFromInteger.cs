using System;
class ExtractBitFromInteger
{
    static void Main()
    {
        uint n;
        bool checkN;
        do
        {
            Console.WriteLine("Please, enter unsigned integer \"n\":");
            string nStr = Console.ReadLine();
            checkN = uint.TryParse(nStr, out n);
        } while (!checkN);
        uint p;
        bool checkP;
        do
        {
            Console.WriteLine("Please, enter unsigned integer for index \"p\":");
            string pStr = Console.ReadLine();
            checkP = uint.TryParse(pStr, out p);
        } while (!checkP);
        int pInt = (int)p;
        int nInt = (int)n;
        int mask = (1 << pInt);
        int mergeMaskN = (nInt & mask);
        int bitP = (mergeMaskN >> pInt);
        Console.WriteLine("The value of the bit #p of \"n\" is {0}.", bitP);
    }
}
