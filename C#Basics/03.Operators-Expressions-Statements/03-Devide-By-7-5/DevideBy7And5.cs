using System;
class DevideBy7And5
{
    static void Main()
    {
        Console.WriteLine("Please, write an integer:");
        int number = int.Parse(Console.ReadLine());
        int devide7Remainder = (number % 7);
        int devide5Remainder = (number % 5);
        bool condition1 = (devide7Remainder == 0);
        bool condition2 = (devide5Remainder == 0);
        if (number == 0)
        {
            Console.WriteLine("The number can NOT be divided (without remainder) by 7 and 5 in the same time.");
        }
        else
        {
            if (condition1 && condition2)
            {
                Console.WriteLine("The number can be divided (without remainder) by 7 and 5 in the same time.");
            }
            else
            {
                Console.WriteLine("The number can NOT be divided (without remainder) by 7 and 5 in the same time.");
            }
        }
    }
}