using System;
using System.Numerics;
class BitsExchangeAdv
{
    static void Main()
    {
        //int n = 1140867093;
        //int p = 3;
        //int q = 24;
        //int k = 3;
        Console.Write("Please, enter \"n\": ");
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        Console.Write("Please, enter \"p\": ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Please, enter \"q\": ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Please, enter \"k\": ");
        int k = int.Parse(Console.ReadLine());
        bool check = ((n < 0) | (n > 4294967295) | (p <= 0) | (q <= 0) | (k <= 0));
        if (check)
        {
            Console.WriteLine("out of range");
        }
        else if (q < (p + k))
        {
            Console.WriteLine("overlapping");
        }
        else
        {
            BigInteger maskNumber = (4294967295 >> (31 - (k - 1)));
            //Console.WriteLine(maskNumber);
            BigInteger maskSequence1 = (maskNumber << p);
            BigInteger mergeMaskSequence1N = n & maskSequence1;
            BigInteger sequence1 = (mergeMaskSequence1N >> p);
            BigInteger maskSequence2 = (maskNumber << q);
            BigInteger mergeMaskSequence2N = n & maskSequence2;
            BigInteger sequence2 = (mergeMaskSequence2N >> q);
            BigInteger wholeMask = (maskSequence1 | maskSequence2);
            BigInteger wholeMaskInverted = ~wholeMask;
            BigInteger nClearedPositions = wholeMaskInverted & n;
            BigInteger sequence1NewPosition = (sequence1 << q);
            BigInteger sequence2NewPosition = (sequence2 << p);
            BigInteger sequencesCombined = (sequence1NewPosition | sequence2NewPosition);
            BigInteger nResult = (nClearedPositions | sequencesCombined);
            Console.WriteLine(nResult);
        }
        
    }
}
