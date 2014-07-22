using System;

class MagicNumbers
{
    static int count = 0;
    static void Main()
    {
        int weight = int.Parse(Console.ReadLine());

        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

        for (int letter1 = 0; letter1 < letters.Length; letter1++)
        {
            for (int letter2 = 0; letter2 < letters.Length; letter2++)
            {
                for (int a = 0; a <= 9; a++)
                {
                    string carNumber = "CA" + a + a + a + a + letters[letter1] + letters[letter2];
                    CheckCarNumberForMagic(carNumber, weight);
                    for (int b = 0; b <= 9 ; b++)
                    {
                        if (b != a)
                        {
                            CheckCarNumberForMagic("CA" + a + b + b + b + letters[letter1] + letters[letter2], weight);
                            CheckCarNumberForMagic("CA" + a + a + a + b + letters[letter1] + letters[letter2], weight);
                            CheckCarNumberForMagic("CA" + a + a + b + b + letters[letter1] + letters[letter2], weight);
                            CheckCarNumberForMagic("CA" + a + b + a + b + letters[letter1] + letters[letter2], weight);
                            CheckCarNumberForMagic("CA" + a + b + b + a + letters[letter1] + letters[letter2], weight);
                            //"CAabbbXY", "CAaaabXY", "CAaabbXY", "CAababXY" and "CAabbaXY"
                        }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }

    private static void CheckCarNumberForMagic(string carNumber, int weight)
    {
        int tempWeight = 0;
        foreach (var ch in carNumber)
	    {
		    if (ch >= '0' && ch <= '9')
            {
                tempWeight += ch - '0';
            }
            else
            {
                tempWeight += (ch - 64) * 10; 
            }
	    }

        if (tempWeight == weight)
        {
            count++;
        }       
    }
}

