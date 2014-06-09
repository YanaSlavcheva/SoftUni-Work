using System;
using System.Numerics;
class PrimeChecker
{
    static void Main() // have in mind that the calculations are slower for the last two numbers, because it takes a lot of operations (and still the minimum count operations)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        IsPrime(n);
    }

    private static void IsPrime(BigInteger n)
    {
        
        if (n == 0)
        {
            Console.WriteLine("false");
        }
        else if (n != 1)
        {
            BigInteger numberDividers = 0;
            for (BigInteger i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    numberDividers = numberDividers + 1;
                    break;

                }
                else
                {
                    numberDividers = numberDividers + 0;
                }
            }

            if (numberDividers == 0)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}


