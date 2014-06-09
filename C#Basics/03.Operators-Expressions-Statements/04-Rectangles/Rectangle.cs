using System;
class Rectangle
{
    static void Main()
    {
        Console.WriteLine("Please, set rectangle's width:");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, set rectangle's height:");
        double height = double.Parse(Console.ReadLine());
        double perimeter = ((width + height) * 2);
        double area = (width * height);
        double perimeterRound = Math.Round(perimeter, 2);
        double areaRound = Math.Round(area, 2);
        Console.WriteLine("The rectangles perimeter is " + perimeterRound + ".");
        Console.WriteLine("The rectangles area is " + areaRound + ".");
    }
}
