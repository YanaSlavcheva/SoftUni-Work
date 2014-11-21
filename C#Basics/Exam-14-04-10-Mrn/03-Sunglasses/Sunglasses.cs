using System;
class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //first row and last row are similar
        Console.WriteLine("{0}{1}{0}", new string('*', 2*n), new string(' ', n));

        //inner part - (n - 3)/2 rows
        for (int i = 0; i < (n - 3) / 2; i++)
        {
            Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), new string(' ', n));
        }

        //middle row
        Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2*n - 2), new string('|', n));

        //inner part - (n - 3)/2 rows
        for (int i = 0; i < (n - 3) / 2; i++)
        {
            Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), new string(' ', n));
        }

        //last row
        Console.WriteLine("{0}{1}{0}", new string('*', 2 * n), new string(' ', n));
    }
}
