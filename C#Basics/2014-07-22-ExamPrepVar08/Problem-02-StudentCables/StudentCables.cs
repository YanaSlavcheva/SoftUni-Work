using System;

class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int totalLenght = 0;


        for (int i = 0; i < n; i++)
        {
            int lenght = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure=="meters")
            {
                lenght *= 100;
            }

            if (lenght >= 20)
            {
                totalLenght += (lenght -3);
            }
        }

        totalLenght += 3;

        int count = totalLenght / 504;
        int remainder = totalLenght % 504;

        Console.WriteLine(count);
        Console.WriteLine(remainder);


    }
}

