using System;
class ModifyBit
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
        int v;
        bool checkV;
        do
        {
            Console.WriteLine("Please, enter a bit value \"v\" - 0 or 1:");
            string vStr = Console.ReadLine();
            checkV = int.TryParse(vStr, out v);
        } while ((!checkV) & (v != 0) & (v != 1));
        int mask = (1 << p);
        int mergeMaskN = (n & mask);
        int bitP = (mergeMaskN >> p);
        bool checkForV = (bitP == v);
        int result;
        if (checkForV == true)
        {
            result = n;
        }
        else
        {
            result = (mask ^ n);
        }
        Console.WriteLine("The value of the modified \"n\" is {0}", result);
    }
}
