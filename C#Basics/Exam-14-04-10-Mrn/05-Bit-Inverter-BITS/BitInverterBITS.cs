using System;
class BitInverterBITS
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int corr = 0;
        int index = 7 + corr;
        for (int i = 0; i < n; i++)
        {  
            int num = int.Parse(Console.ReadLine());
            for (int j = 8; j >= 0; j--)
            {
                if (index >= 0)
                {
                    num = (1 << index) ^ num;
                    index -= step;
                }
                else
                {
                    Console.WriteLine(num);
                    index += 8;
                    break;
                }
            }
        }
    }
}
