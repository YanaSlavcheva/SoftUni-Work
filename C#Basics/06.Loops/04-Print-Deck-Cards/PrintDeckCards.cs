using System;
class PrintDeckCards
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5" , "6" , "7" , "8" , "9" , "10" , "J" , "Q" , "K" , "A" };
        int numberSuits = 4;
        int numberCards = 13;
        for (int i = 0; i < numberCards; i++)
        {
            string card = cards[i];
            for (int j = 1; j <= numberSuits; j++)
            {
                switch (j)
                {
                    case 1: Console.Write("{0,2}\u2663", card); break;
                    case 2: Console.Write("{0,2}\u2666", card); break;
                    case 3: Console.Write("{0,2}\u2665", card); break;
                    case 4: Console.WriteLine("{0,2}\u2660", card); break;
                }
            }
        }

    }
}
