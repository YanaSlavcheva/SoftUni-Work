using System;
using System.Collections.Generic;
using System.Linq;
class NineDigitMagicNumbers
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());
        long diff = long.Parse(Console.ReadLine());

        List<long> results = new List<long>();
        
        for (long a = 1; a < 8; a++)
        {
            for (long b = 1; b < 8; b++)
            {
                for (long c = 1; c < 8; c++)
                {
                    for (long d = 1; d < 8; d++)
                    {
                        for (long e = 1; e < 8; e++)
                        {
                            for (long f = 1; f < 8; f++)
                            {
                                for (long g = 1; g < 8; g++)
                                {
                                    for (long h = 1; h < 8; h++)
                                    {
                                        for (long i = 1; i < 8; i++)
                                        {
                                            long currResult = 0;
                                            long currSum = a + b + c + d + e + f + g + h + i;
                                            long curr3rdThree = 100 * g + 10 * h + i;
                                            long curr2ndThree = 100 * d + 10 * e + f;
                                            long curr1stThree = 100 * a + 10 * b + c;
                                            long currDiff01 = curr3rdThree - curr2ndThree;
                                            long currDiff02 = curr2ndThree - curr1stThree;
                                            bool check01 = (currDiff01 == currDiff02);
                                            bool check02 = (currDiff02 == diff);
                                            bool check03 = (currSum == sum);
                                            bool check04 = (curr1stThree < curr2ndThree) || (curr1stThree == curr2ndThree);
                                            bool check05 = (curr2ndThree < curr3rdThree) || (curr2ndThree == curr3rdThree);
                                            if (check01 && check02 && check03 && check04 && check05)
                                            {
                                                currResult = curr1stThree * 1000000 + curr2ndThree * 1000 + curr3rdThree;
                                                results.Add(currResult);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        results.Sort();

        if (results.Count != 0)
        {
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
