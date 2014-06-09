using System;

class PrintLongSequence
{
    static void Main(string[] args)
    {
        int firstNumber = 1;
        for (int i = 0; i < 1000; i++)
        {
            firstNumber += 1;

            if (firstNumber % 2 == 0)
            {
                Console.Write(firstNumber + ", ");
            }
            else
            {
                Console.Write(firstNumber*(-1) + ", ");
            }
        }
    }
}