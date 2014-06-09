using System;
class Sort3Numbers
{
    static void Main()
    {
        //float num1 = 5;
        //float num2 = 1;
        //float num3 = 2;
        Console.WriteLine("Entre 3 real numbers: ");
        float num1 = float.Parse(Console.ReadLine());
        float num2 = float.Parse(Console.ReadLine());
        float num3 = float.Parse(Console.ReadLine());
        if (num1 > num2)
        {
            if (num2 > num3)
            {
                Console.WriteLine("{0} {1} {2}", num1, num2, num3);
            }
            else
            {
                if (num1 > num3)
                {
                    Console.WriteLine("{0} {1} {2}", num1, num3, num2);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", num3, num1, num2);
                }
            }
        }
        else
        {
            if (num1 > num3)
            {
                Console.WriteLine("{0} {1} {2}", num2, num1, num3);
            }
            else
            {
                if (num2 > num3)
                {
                    Console.WriteLine("{0} {1} {2}", num2, num3, num1);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", num3, num2, num1);
                }
            }
        }
    }
}
