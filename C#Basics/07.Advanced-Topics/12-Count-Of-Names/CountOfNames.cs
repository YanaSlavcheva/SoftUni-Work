using System;
using System.Collections.Generic;
using System.Linq;
class CountOfNames
{
    static void Main()
    {
        List<string> names = new List<string>(Console.ReadLine().Split(' ')); //we read the input
        Dictionary<string, int> finalCount = new Dictionary<string,int>(); //we will put the items and their count here
        names.Sort(); 

        //now we fill the dictionary
        finalCount[names[0]] = 1;
        int countTemp = 1;

        for (int i = 1; i < names.Count; i++)
		{
			string currentLetter = names[i];
            string previousLetter = names[i - 1];
            if (currentLetter == previousLetter)
	        {
		        countTemp++;
                finalCount[names[i]] = countTemp;
	        }
            else
	        {
                countTemp = 1;
                finalCount[names[i]] = countTemp;
	        }
		}

        // and we print the dictionary
        foreach (var entry in finalCount)
        {
            Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
        }
    }
}
