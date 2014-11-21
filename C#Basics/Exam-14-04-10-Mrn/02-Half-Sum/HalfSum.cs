using System;
class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numLeft = new int[n];
        int[] numRight = new int[n];

        int sumLeft = 0;
        int sumRight = 0;

        for (int i = 0; i < n; i++)
        {
            numLeft[i] = int.Parse(Console.ReadLine());
            sumLeft += numLeft[i];
        }
        for (int i = 0; i < n; i++)
        {
            numRight[i] = int.Parse(Console.ReadLine());
            sumRight += numRight[i];
        }

        int difference = Math.Abs(sumLeft - sumRight);
        if (sumLeft == sumRight)
        {
            Console.WriteLine("Yes, sum={0}", sumLeft);
        }
        else
        {
            Console.WriteLine("No, diff={0}", difference);
        }
    }
}
