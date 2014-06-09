using System;
class OddOrEven
{
    static void Main()
    {
        Console.WriteLine("Please, write an integer:");
        int number = int.Parse (Console.ReadLine());
        int result = number % 2;
        if (result == 0)
        {
            Console.WriteLine("The number is even.");
        }
        else
        {
            Console.WriteLine("The number is odd.");
        }
    }
}
