using System;
using System.Linq;
class DecimalToBinary
{
    static void Main()
    {
        //int n = 13;
        Console.WriteLine("Enter decimal number: ");
        long n = long.Parse(Console.ReadLine());
        string[] binaryNumber = new string[64];
        for (int i = 0; i < 64; i++)
        {
            long remainder = n % 2;
            string remainderString = remainder.ToString();
            binaryNumber[i] = remainderString;
            n = n / 2;
            if (n == 0)
            {
                goto BREAK;
            }
        }
        BREAK:
        Array.Reverse(binaryNumber);
        for (int j = 0; j < binaryNumber.Length; j++)
        {
            Console.Write(binaryNumber[j]);
        }
        Console.WriteLine();
    }
}
