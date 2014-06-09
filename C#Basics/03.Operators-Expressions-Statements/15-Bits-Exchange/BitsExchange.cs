using System;
using System.Numerics;
class BitsExchange
{
    static void Main()
    {
        //int n = 1140867093;
        Console.Write("Please, enter \"n\": ");
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger maskSequence1 = (7 << 3);
        BigInteger mergeMaskSequence1N = n & maskSequence1;
        BigInteger sequence1 = (mergeMaskSequence1N >> 3);
        BigInteger maskSequence2 = (7 << 24);
        BigInteger mergeMaskSequence2N = n & maskSequence2;
        BigInteger sequence2 = (mergeMaskSequence2N >> 24);
        BigInteger wholeMask = (maskSequence1 | maskSequence2);
        BigInteger wholeMaskInverted = ~wholeMask;
        BigInteger nClearedPositions = wholeMaskInverted & n;
        BigInteger sequence1NewPosition = (sequence1 << 24);
        BigInteger sequence2NewPosition = (sequence2 << 3);
        BigInteger sequencesCombined = (sequence1NewPosition | sequence2NewPosition);
        BigInteger nResult = (nClearedPositions | sequencesCombined);
        Console.WriteLine(nResult);
    }
}
