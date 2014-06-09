using System;
class NumbersAsWords
{
    static void Main()
    {
        //int n = 217;
        Console.Write("Enter a number in the range [0..999]: ");
        int n = int.Parse(Console.ReadLine());
        int numHundreds = (n / 100) % 10;
        int numTens = (n / 10) % 10;
        int numDigits = (n / 1) % 10;
        if (n >= 100)
        {
            WriteHundreds(numHundreds);
            WriteTens(numTens, numDigits);
            WriteDigits(numTens, numDigits, numHundreds);
        }
        else if (n < 100 && n >= 10)
        {
            WriteTens(numTens, numDigits);
            WriteDigits(numTens, numDigits, numHundreds);
        }
        else if (n < 10)
        {
            WriteDigits(numTens, numDigits, numHundreds);
        }
    }

    private static void WriteHundreds(int numHundreds)
    {
        switch(numHundreds)
        {
            case 1:
                Console.Write("one");
                break;
            case 2:
                Console.Write("two");
                break;
            case 3:
                Console.Write("three");
                break;
            case 4:
                Console.Write("four");
                break;
            case 5:
                Console.Write("five");
                break;
            case 6:
                Console.Write("six");
                break;
            case 7:
                Console.Write("seven");
                break;
            case 8:
                Console.Write("eight");
                break;
            case 9:
                Console.Write("nine");
                break;
        }
        Console.Write(" hundred ");
    }

    private static void WriteTens(int numTens, int numDigits)
    {
        if ((numTens != 0) || (numDigits != 0))
        {
            Console.Write("and ");
        }
        switch (numTens)
        {
            case 1:
                if (numDigits == 0)
                {
                    Console.Write("ten");
                }
                else 
                {
                    WriteTenToTwenty(numDigits);
                }
                break;
            case 2:
                Console.Write("twenty ");
                break;
            case 3:
                Console.Write("thirty ");
                break;
            case 4:
                Console.Write("fourty ");
                break;
            case 5:
                Console.Write("fifty ");
                break;
            case 6:
                Console.Write("sixty ");
                break;
            case 7:
                Console.Write("seventy ");
                break;
            case 8:
                Console.Write("eighty ");
                break;
            case 9:
                Console.Write("ninety ");
                break;
        }
    }

    private static void WriteTenToTwenty(int numDigits)
    {
        switch (numDigits)
        {
            case 1:
                Console.Write("eleven");
                break;
            case 2:
                Console.Write("twelve");
                break;
            case 3:
                Console.Write("thirteen");
                break;
            case 4:
                Console.Write("fourteen");
                break;
            case 5:
                Console.Write("fifteen");
                break;
            case 6:
                Console.Write("sixteen");
                break;
            case 7:
                Console.Write("seventeen");
                break;
            case 8:
                Console.Write("eightteen");
                break;
            case 9:
                Console.Write("nineteen");
                break;
        }
    }

    private static void WriteDigits(int numTens, int numDigits, int numHundreds)
    {
        if (numTens != 1)
        {
            switch (numDigits)
            {
                case 0:
                    if ((numHundreds == 0) && (numTens == 0))
                    {
                        Console.Write("zero");
                    }
                    break;
                case 1:
                    Console.Write("one");
                    break;
                case 2:
                    Console.Write("two");
                    break;
                case 3:
                    Console.Write("three");
                    break;
                case 4:
                    Console.Write("four");
                    break;
                case 5:
                    Console.Write("five");
                    break;
                case 6:
                    Console.Write("six");
                    break;
                case 7:
                    Console.Write("seven");
                    break;
                case 8:
                    Console.Write("eight");
                    break;
                case 9:
                    Console.Write("nine");
                    break;
            }
        }
    }
}

