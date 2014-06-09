using System;
using System.Collections.Generic;
class PrimesInRange
{
    static void Main()
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());

        FindPrimesInRange(startNum, endNum);
    }

    private static void FindPrimesInRange(int startNum, int endNum)
    {
        if (startNum > endNum)
        {
            Console.WriteLine("(emptylist ;))");
        }
        else
        {
            List<int> primeNumbersInRange = new List<int>();

            for (int n = startNum; n <= endNum; n++)
            {
                int numberDividers = 0;
                if (n != 1 && n != 0)
                {
                    for (long i = 2; i <= n / 2; i++)
                    {
                        if (n % i == 0)
                        {
                            numberDividers = numberDividers + 1;
                            break;
                        }
                    }

                    if (numberDividers == 0)
                    {
                        primeNumbersInRange.Add(n);
                    }
                }
            }
            for (int i = 0; i < primeNumbersInRange.Count - 1; i++)
            {
                Console.Write("{0}, ", primeNumbersInRange[i]);
            }
            Console.WriteLine(primeNumbersInRange[primeNumbersInRange.Count - 1]);
        }
    }
}
