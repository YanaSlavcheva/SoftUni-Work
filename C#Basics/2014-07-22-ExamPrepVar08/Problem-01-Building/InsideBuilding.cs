using System;

class InsideBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        for (int i = 0; i < 5; i++)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool check = ((x >= h && x <= 2*h) && (y >= h && y <= 4 * h)) ||
                         ((x >= 0 && x <= 3*h) && (y >= 0 && y <= h));

            if (check)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}

