using System;
class Calculate1
{
    static void Main()
    {
        Console.Write("Please,enter integer n = ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please,enter integer x = ");
        int x = Convert.ToInt32(Console.ReadLine());
        double factorial = 1;
        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            double xPow = Math.Pow(x, i);
            double addend = factorial / xPow;
            sum += addend;
        }
        Console.WriteLine("{0:0.00000}", sum);
    }
}
