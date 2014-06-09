using System;
class CheckPlayCard
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
        Console.Write("Enter string to be checked: ");
        string stringToCheck = Console.ReadLine();
        int counter = 0;
        for (int i = 0; i < cards.Length; i++)
        {
            bool check = (stringToCheck == cards[i]);
            if (check)
            {
                counter++;
            }
        }
        if (counter == 1)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
