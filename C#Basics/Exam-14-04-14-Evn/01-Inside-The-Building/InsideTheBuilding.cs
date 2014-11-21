using System;
class InsideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        int[] coordX = new int[5];
        int[] coordY = new int[5];

        for (int i = 0; i < 5; i++)
        {
            coordX[i] = int.Parse(Console.ReadLine());
            coordY[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 5; i++)
        {
            if ((coordY[i] <= h) && (coordX[i] <= 3*h) && (coordX[i] >= 0) && (coordY[i] >= 0))
            {
                Console.WriteLine("inside");
            }
            else if ((coordY[i] >= h) && (coordY[i] <= 4*h) && (coordX[i] >= h) && (coordX[i] <= 2*h))
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
