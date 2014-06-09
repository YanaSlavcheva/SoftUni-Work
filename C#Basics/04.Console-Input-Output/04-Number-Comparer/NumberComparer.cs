using System;
class NumberComparer
{
    static void Main()
    {
        double a;
        double b;
        Console.WriteLine("Please, enter two numbers, seperated by space: ");
        string numbersStr = Console.ReadLine();
        string[] numbersArr = numbersStr.Split(' ');
        double.TryParse(numbersArr[0], out a);
        double.TryParse(numbersArr[1], out b);
        double[] numbers = { a, b };
        double greaterNumber = a;
        bool check = (a > b);
        while (!check)
        {
            greaterNumber = b;
            break;
        } ;
        Console.WriteLine("The greater number is: {0}.", greaterNumber);
    }
}
