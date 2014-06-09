using System;
using System.Collections.Generic;
using System.Linq;

class CountOfLetters
{
    static void Main()
    {
        List<string> letters = new List<string>(Console.ReadLine().Split(' ')); //we read the input
        Dictionary<string, int> finalCount = new Dictionary<string,int>(); //we will put the items and their count here
        letters.Sort(); 

        //now we fill the dictionary
        finalCount[letters[0]] = 1;
        int countTemp = 1;

        for (int i = 1; i < letters.Count; i++)
		{
			string currentLetter = letters[i];
            string previousLetter = letters[i - 1];
            if (currentLetter == previousLetter)
	        {
		        countTemp++;
                finalCount[letters[i]] = countTemp;
	        }
            else
	        {
                countTemp = 1;
                finalCount[letters[i]] = countTemp;
	        }
		}

        // and we print the dictionary
        foreach (var entry in finalCount)
        {
            Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
        }
    }
}