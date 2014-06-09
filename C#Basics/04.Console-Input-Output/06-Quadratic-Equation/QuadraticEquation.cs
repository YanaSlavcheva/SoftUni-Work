using System;
using System.Text;
class QuadraticEquation
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        double a;
        double b;
        double c;
        bool checkPrimal;
        do
        {
            Console.Write("Please, enter a, b and c, seperated by space: ");
            string doublesPrimal = Console.ReadLine();
            string[] doubles = doublesPrimal.Split(' ');
            double.TryParse(doubles[0], out a);
            double.TryParse(doubles[1], out b);
            double.TryParse(doubles[2], out c);
            checkPrimal = (a is double) && (b is double) && (c is double);
        } while (!checkPrimal);
        double sqrRoot = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
        double x1 = (-b + sqrRoot) / (2 * a);
        double x2 = (-b - sqrRoot) / (2 * a);
        bool check = ((double.IsNaN(x1)) && (double.IsNaN(x2)));
        if (!check)
        {
            Console.WriteLine("x\u2081={0}, x\u2082={1}", x1, x2); //in order to view the subscript symbols 1 and 2 in the console, please use font Consolas
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}
