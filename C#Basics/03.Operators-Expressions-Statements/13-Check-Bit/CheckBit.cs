using System;
class CheckBit
{
    static void Main()
    {
        int n;
        bool checkN;
        do
        {
            Console.WriteLine("Please, enter integer \"n\":");
            string nStr = Console.ReadLine();
            checkN = int.TryParse(nStr, out n);
        } while (!checkN);
        int p;
        bool checkP;
        do
        {
            Console.WriteLine("Please, enter integer for index \"p\":");
            string pStr = Console.ReadLine();
            checkP = int.TryParse(pStr, out p);
        } while (!checkP);
        int mask = (1 << p);
        int mergeMaskN = (n & mask);
        int bitP = (mergeMaskN >> p);
        bool checkFor1 = (bitP == 1);
        Console.WriteLine("The statement that the bit at position \"p\" is \"1\" is {0}.", checkFor1);
    }
}
