using System;
using System.Text;
class ASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.ASCII;
        for (byte counter = 0; counter < 255; counter++)
        {
            Console.WriteLine(counter + " " + (char)counter);
        }
    }
}
