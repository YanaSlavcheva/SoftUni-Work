using System;
class PointInCircle
{
    static void Main()
    {
        Console.WriteLine("Give \"x\" coordinate of the point:");
        double coordX = double.Parse(Console.ReadLine());
        Console.WriteLine("Give \"y\" coordinate of the point:");
        double coordY = double.Parse(Console.ReadLine());
        double centerX = 0;
        double centerY = 0;
        double radius = 2;
        double substrX = coordX - centerX;
        double substrY = coordY - centerY;
        bool check = (Math.Pow(substrX, 2) + Math.Pow(substrY, 2)) <= Math.Pow(radius, 2);
        if (check == true)
	    {
		     Console.WriteLine("The given point (x,  y) is inside a circle K({0, 0}, 2).");
	    }
        else
	    {
            Console.WriteLine("The given point (x,  y) is NOT inside a circle K({0, 0}, 2).");
	    }
    }
}
