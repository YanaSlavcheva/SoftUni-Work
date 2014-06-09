using System;
class MatrixNumbers
{
    static void Main()
    {
        int n;
        bool check;
        do
        {
            Console.Write("Please, enter integer n (1 < n < 20): ");
            int.TryParse(Console.ReadLine(), out n);
            check = (1 < n) && (n < 20);
        } while (!check);
        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= (n + i - 1); j++)
            {
                Console.Write("{0, 2}" + " ", j);
            }
            Console.WriteLine("\n");
        }
    }
}
