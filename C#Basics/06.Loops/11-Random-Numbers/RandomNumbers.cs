using System;
class RandomNumbers
{
    static void Main()
    {
        //int n = 5;
        //int min = 0;
        //int max = 100;
        Console.WriteLine("Please, enter 3 integers - n, min and max (min ≤ max): ");
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomInt = random.Next(min, max);
            Console.WriteLine(randomInt);
        }
    }
}
