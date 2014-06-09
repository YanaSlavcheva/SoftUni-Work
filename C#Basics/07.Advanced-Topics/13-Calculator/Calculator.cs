using System;
using System.Collections.Generic;
using System.Linq;

class Calculator
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        List<string> sites = new List<string>();
        List<double> times = new List<double>();
        Console.WriteLine("Enter each load time followed by [enter] and press [enter] again when finished");
        string input = Console.ReadLine();
        while (input != "")
        {
            input = input.Substring(18);
            string[] divided = input.Split();
            sites.Add(divided[0]);
            times.Add(double.Parse(divided[1]));
            input = Console.ReadLine();
        }
        var dict = new Dictionary<string, double>();
        foreach (var site in sites)
        {
            if (!dict.ContainsKey(site))
            {
                dict.Add(site, 0);
            }
        }
        for (int j = 0; j < dict.Count; j++)
        {
            int count = 0;
            double sum = 0;
            for (int i = 0; i < sites.Count; i++)
            {
                if (sites[i] == dict.ElementAt(j).Key)
                {
                    count++;
                    sum += times[i];
                }
            }
            double average = sum / count;
            dict[dict.ElementAt(j).Key] = average;
        }
        foreach (var pair in dict)
        {
            Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}