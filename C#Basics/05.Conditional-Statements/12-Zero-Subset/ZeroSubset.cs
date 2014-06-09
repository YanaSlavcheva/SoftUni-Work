using System;
using System.Collections.Generic;
class ZeroSubset
{
    static void Main()
    {
        //int[] numbers = {3, -2, 1, 1, 8};
        int[] numbers = { 3, 1, -7, 35, 22 };
        //int[] numbers = { 1, 3, -4, -2, -1 };
        double numberCombinations = Math.Pow(2, 5);
        int currentSum = 0;
        int wantedSum = 0;
        int countSums = 0;
        List<int> sumMembers = new List<int>();
        for (int i = 1; i < numberCombinations; i++)
        {
            //while the number is greater than 0, we count bits, if bits are exactly 2, we execute the rest
            sumMembers.Clear();
            for (int j = 0; j < 5; j++)
            {
                int mask = 1 << j;
                int iAndMask = i & mask;
                int bitJ = iAndMask >> j;
                if (bitJ == 1)
                {
                    currentSum += numbers[j];
                    sumMembers.Add(numbers[j]);
                }  
            }
            // in stead of this below we will fill a list with all sums
            if (currentSum == wantedSum)
            {
                countSums++;
                int sumMembersCount = sumMembers.Count;
                int sumMembersLast = sumMembers[sumMembersCount - 1];
                sumMembers.RemoveAt(sumMembersCount - 1);
                foreach (var item in sumMembers)
                {
                    Console.Write("{0} + ", item);
                }
                Console.WriteLine("{0} = 0", sumMembersLast);
                Console.WriteLine();
            }
            currentSum = 0;
        }

        if (countSums == 0)
        {
            Console.WriteLine("no zero subsets");
        }
        Console.ReadLine();
    }
}
