using System;
class Sum3Integers
{
    static void Main()
    {
        //Console.Write("Please, enter three intefers seperated by \",\": ");
        //string s = Console.ReadLine();
        //string[] values = s.Split(',');
        //int a = int.Parse(values[0]);
        //int b = int.Parse(values[1]);
        //int c = int.Parse(values[2]);
        //int sum = a + b + c;
        //Console.WriteLine("The sum of the integers You entered is {0}.", sum);
        double sum = 0;
        Console.WriteLine("Please, enter three numbers: ");
        for (int i = 0; i < 3; i++)
        { 
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("The sum of the three numbers is {0}.", sum);
    }
}
