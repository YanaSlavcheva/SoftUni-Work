using System;
class FactorialNandK
{
    static void Main()
    {
        int n;
        int k;
        bool check;
        do
        {
            Console.Write("Please, enter integers n and k (1 < k < n < 100), seperated by space: ");
            string integersPrimal = Console.ReadLine();
            string[] integers = integersPrimal.Split(' ');
            int.TryParse(integers[0], out n);
            int.TryParse(integers[1], out k);
            check = (1 < k) && (k < n) && (n < 100);
        } while (!check);
        long factorial = 1;
        for (int i = (k + 1) ; i <= n ; i++)
        {
            factorial *= i;
        }
        Console.WriteLine("{0:0}", factorial);
    }
}
