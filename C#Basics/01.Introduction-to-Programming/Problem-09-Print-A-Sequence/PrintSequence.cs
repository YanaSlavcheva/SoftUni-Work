using System;
class PrintSequence
{
    static void Main()
    {
        for (int num = 2; num < 12; num++)
        {
            if (num % 2 == 0)
            {
                Console.Write(num + ", ");
            }

            else
            {
                Console.Write(num*(-1) + ", ");
            }
        }
    }
}
