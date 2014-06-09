using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sample = {0, 1, 2, 3, 1, 5, 6 };
            int[] indexes = new int[sample.Length];
            for (int i = 0; i < 2; i++) // put countIndexes
            {
                int index1 = Array.IndexOf(sample, 1);
                Console.WriteLine(index1); //assign in array
                sample[index1] = 0;
            }
            
        }
    }
}
