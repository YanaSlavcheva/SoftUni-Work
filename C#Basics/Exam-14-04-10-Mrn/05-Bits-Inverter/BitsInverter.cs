using System;
class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string[] binaryNums = new string[n];
        //we read the numbers from the console and add them to a array as strings
        for (int i = 0; i < n; i++)
        {
            int currNum = int.Parse(Console.ReadLine());
            string currNumBinary = Convert.ToString(currNum, 2);
            //we add zeroes to the left, if necessary in order to have 8 bits (otherwise the left zeroes are cut)
            string addBits = new string('0', (8-currNumBinary.Length));
            string currNumBinary8Bits = (addBits + currNumBinary);
            binaryNums[i] = currNumBinary8Bits;
        }
        //we combine the Bits from all the numbers in one string
        string allBitsToInvert = "";
        foreach (var item in binaryNums)
        {
            allBitsToInvert += ("" + item);
        }
        //Console.WriteLine(allBitsToInvert);
        //we have 8*n Bits in the allBitsToInvert string

        ////in order to work with bits :) I convert all the 8*n bits into decimal number
        //long resultDecimal = Convert.ToInt64(allBitsToInvert, 2);
        //Console.WriteLine(resultDecimal);

        int numBits = 8 * n;
        string resultConvertedBits = "";
        int stepIndex = 0;
        for (int i = 0; i < numBits; i++)
        {
            int nrBit = 1 + (stepIndex * step) - 1;
            if (i != nrBit)
            {
                resultConvertedBits += ("" + allBitsToInvert[i]);
            }
            else if (i == nrBit)
            {
                if (allBitsToInvert[i] == '0')
                {
                    resultConvertedBits += ("" + 1);
                }
                else if (allBitsToInvert[i] == '1')
                {
                    resultConvertedBits += ("" + 0);
                }
                stepIndex++;
            }
        }
        //Console.WriteLine(resultConvertedBits);
        //we need to split the string into two strings of 8

        string[] results = new string[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 8*i; j < 8*(i + 1); j++)
            {
                results[i] += ("" + resultConvertedBits[j]);
            }
        }

        //long resultDecimal = Convert.ToInt64(resultConvertedBits, 2);
        //Console.WriteLine(resultConvertedBits);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Convert.ToInt64(results[i], 2));
        }
    }
}
