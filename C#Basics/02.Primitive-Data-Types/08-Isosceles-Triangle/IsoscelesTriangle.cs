using System;
using System.Text;
class IsoscelesTriangle
{
    static void Main()
    {
//        Console.OutputEncoding = Encoding.UTF8;
//        char copyRight = '©';
//        Console.WriteLine(@"
//    {0}
//   {0} {0}
//  {0}   {0}
// {0} {0} {0} {0}", copyRight);
        Console.OutputEncoding = Encoding.UTF8;
        char copyRight = '©';
        int n = 4;
        for (int i = 1; i < n; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("{0}", copyRight);
        
    }
}

