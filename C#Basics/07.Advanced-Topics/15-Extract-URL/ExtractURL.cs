using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractURL
{

    static List<string> GetLinks(string text)
    {
        List<string> links = new List<string>();

        Regex urls = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*",
                               RegexOptions.IgnoreCase);

        MatchCollection matches = urls.Matches(text);
        foreach (Match match in matches)
        {
            links.Add(match.Value);
        }

        return links;
    }
    static void Main()
    {
        string someText = Console.ReadLine();

        List<string> urls = GetLinks(someText).Distinct().ToList(); //Again use Distinct if you dont want repeated elements

        Console.WriteLine();
        Console.WriteLine("The url links are:");
        Console.WriteLine();

        foreach (var item in urls)
        {
            Console.WriteLine(item);
        }
    }
}
