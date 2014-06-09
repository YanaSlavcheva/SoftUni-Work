using System;
class CirclePandA
{
    static void Main()
    {
        Console.WriteLine("Please, enter radius r of a circle: ");
        double r = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * r;
        double area = Math.PI * Math.Pow(r, 2);
        Console.WriteLine("The perimeter of the circle is {0:0.00}.", perimeter);
        Console.WriteLine("The area of the circle is {0:0.00}.", area);
    }
}
