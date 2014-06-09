using System;
class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Enter positive integer number here (between 0 and 100) to check if is prime \nn = ");
        int n = int.Parse(Console.ReadLine());
        int numberDividers = 0;

        if ((n < 0) || (n > 100))
        {
            Console.WriteLine("You have entered invaled number. \nPlease try again using positive number(n <= 100).");
        }

        else
        {
            if (n != 1)
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        numberDividers = numberDividers + 1;

                    }
                    else
                    {
                        numberDividers = numberDividers + 0;
                    }
                }

                if (numberDividers == 0)
                {
                    Console.WriteLine("The number {0} is prime.", n);
                }
                else
                {
                    Console.WriteLine("The number {0} isn NOT prime.", n, numberDividers);
                }
            }
            else
            {
                Console.WriteLine("The number {0} isn NOT prime by definition.", n);
            }
                
        }

    }
}

