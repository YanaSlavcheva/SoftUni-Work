using System;
class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countUsedCables = 0;
        int usedCablesLength = 0;
        //string units = "meters";

        for (int i = 0; i < n; i++)
        {
            int currentLength = int.Parse(Console.ReadLine());
            string units = Console.ReadLine();
            if ((units == "centimeters") && (currentLength >= 20))
            {
                countUsedCables++;
                usedCablesLength += currentLength;
            }
            else if (units == "meters")
            {
                countUsedCables++;
                usedCablesLength += (currentLength*100);
            }
        }

        int usedCablesLengthCut = (usedCablesLength - (countUsedCables - 1) * 3);

        int studentCables = usedCablesLengthCut / 504;
        int remainderCable = usedCablesLengthCut % 504;

        Console.WriteLine(studentCables);
        Console.WriteLine(remainderCable);
    }
}
