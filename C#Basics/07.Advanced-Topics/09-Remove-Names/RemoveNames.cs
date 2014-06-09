using System;
using System.Collections.Generic;
using System.Linq;
class RemoveNames
{
    static void Main()
    {
        List<string> firstList = new List<string>(Console.ReadLine().Split(' '));
        List<string> secondList = new List<string>(Console.ReadLine().Split(' '));

        for (int i = 0; i < secondList.Count; i++)
        {
            for (int j = 0; j < firstList.Count; j++)
            {
                if (firstList[j] == secondList[i])
                {
                    firstList.RemoveAt(j);
                    j--;
                }
            }
        }
        foreach (var item in firstList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
