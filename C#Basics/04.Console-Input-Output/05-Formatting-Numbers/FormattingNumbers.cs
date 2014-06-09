using System;
class FormattingNumbers
{
    static void Main()
    {
        int a;
        bool checkA;
        do
        {
            Console.Write("Please, enter integers a (0 <= a <= 500): ");
            string aPrimal = Console.ReadLine();
            int.TryParse(aPrimal, out a);
            checkA = (0 <= a) && (a <= 500);
        } while (!checkA);
        float b;
        float c;
        bool checkBC;
        do
        {
            Console.Write("Please, enter floating-point b and a floating-point c, seperated by space: ");
            string floatsPrimal = Console.ReadLine();
            string[] floats = floatsPrimal.Split(' ');
            float.TryParse(floats[0], out b);
            float.TryParse(floats[1], out c);
            checkBC = (b is float) && (c is float);
        } while (!checkBC);
        //int a = 254;
        //float b = 11.6f;
        //float c = 0.5f;
        var stringA = Convert.ToString(a, 2).PadLeft(10, '0');
        Console.WriteLine("|{0,-10:X}|{3,10}|{1,10:0.00}|{2,-10:0.000}|", a, b, c, stringA);
    }
}
// {index[,alignment][:formatString]}
// Convert.ToString(result, 2).PadLeft(16, '0'));