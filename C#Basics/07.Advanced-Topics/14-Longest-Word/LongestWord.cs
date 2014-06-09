using System;

class LongestWord
{
    static void Main()
    {
        string someText = Console.ReadLine();
        string[] allWords = someText.Split(new char[] { ' ', ',', ':', ';', '.' },
                                                StringSplitOptions.RemoveEmptyEntries);
 
        int longestWordIndex = 0;
        for (int i = 1; i < allWords.Length; i++)
        {
            if (allWords[i].Length > allWords[longestWordIndex].Length)
            {
                longestWordIndex = i;
            }
        }
 
        Console.WriteLine(allWords[longestWordIndex]);
    }
}
