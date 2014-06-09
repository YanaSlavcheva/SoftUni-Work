using System;
using System.Numerics;
class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter binary number: ");
        string nBinaryString = Console.ReadLine();
        int[] nBinaryArray = new int[nBinaryString.Length];
        for (int i = 0; i < nBinaryString.Length; i++)
        {
            nBinaryArray[i] = Convert.ToInt32(Convert.ToString(nBinaryString[i]));
        }
        Array.Reverse(nBinaryArray);
        double nDecimal = 0;
        for (int j = 0; j < nBinaryString.Length; j++)
        {
            if (nBinaryArray[j] == 1)
            {
                nDecimal += Math.Pow(2, j);
            }
            else
            {
                nDecimal = nDecimal + 0;
            }
        }
        long nDecimalLong = Convert.ToInt64(nDecimal);
        Console.WriteLine(nDecimalLong);
    }
}
 


//double nBinary = 1110000110000101100101000000;
//        double nDecimal = 0;
//        for (int i = 0; i < 64; i++)
//        {
//            double check = (nBinary / (Math.Pow(10, i)));
//            double checkRounded = Math.Round(check, 0);
//            if ((checkRounded % 10) == 1)
//            {
//                nDecimal += Math.Pow(2, i);
//            }
//            else
//            {
//                nDecimal = nDecimal + 0;
//            }
//        }
//        Console.WriteLine(nDecimal);
