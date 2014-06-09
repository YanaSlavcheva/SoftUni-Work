using System;
class PointInCircleOutRectangle
{
    static void Main()
        //NOTE! One of the assignment's examples is not correct - the point with x=2,5 and y=1,5 should give result NO, because it is obviously outside of the circle!!!
    {
        Console.WriteLine("Give \"x\" coordinate of the point:");
        double coordX = double.Parse(Console.ReadLine());
        Console.WriteLine("Give \"y\" coordinate of the point:");
        double coordY = double.Parse(Console.ReadLine());
        double centerX = 1;
        double centerY = 1;
        double radius = 1.5;
        double substrX = coordX - centerX;
        double substrY = coordY - centerY;
        bool check = (Math.Pow(substrX, 2) + Math.Pow(substrY, 2)) <= Math.Pow(radius, 2);
        if ((check == true) && (coordY > 1))
        {
            Console.WriteLine("The given point (x,  y) is inside the circle and outside of the rectangle.");
        }
        else
        {
            Console.WriteLine("The given point (x,  y) is NOT where it should be.");
        }
    }
}
