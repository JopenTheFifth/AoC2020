using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\source\repos\AoC_Day_5\AoC_Day_5\inputs.txt");
            var outcome = myfile.ReadToEnd();
            string[] dataSetString = outcome.Split(new string[] { Environment.NewLine + Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            List<int> results = new List<int>();
            for (int i = 0; i < dataSetString.Length; i++)
            { 
                var parsed = dataSetString[i].Split(new[] { Environment.NewLine, " " }, StringSplitOptions.None);
                //940 iterations
                for (int j = 0; j < parsed.Length; j++)
                {
                    MyTuple NumberSet1 = new MyTuple(0, 127);
                    MyTuple NumberSet2 = new MyTuple(0, 7);

                    //iteration for each character in a line (10)
                    for (int k = 0; k < parsed[j].Length - 3; k++)
                    {
                        //process the first 7 chars with ref numberSet1
                        ProcessData(parsed[j][k], ref NumberSet1);
                    }
                    for (int y = parsed[j].Length - 3; y < parsed[j].Length; y++)
                    {
                        //process the last 3 chars with ref numberSet2
                        ProcessData(parsed[j][y], ref NumberSet2);
                    }

                    var number = (NumberSet1.UpperBound * 8) + NumberSet2.LowerBound;
                    results.Add(number);
                }
            }
            for (int i = 0; i < results.Count; i++)
            {
                if (!results.Contains(i))
                {
                    Console.WriteLine($"{i} {results.Contains(i -1)} - {results.Contains(i + 1)} ");
                }
            }
        }
        public static MyTuple ProcessData(char input, ref MyTuple numberRange)
        {
            var difference = numberRange.UpperBound - numberRange.LowerBound;
            switch (input)
            {
                case 'F':
                    numberRange.UpperBound = numberRange.UpperBound - ( difference / 2) - 1;
                    return numberRange;

                case 'B':
                    
                    numberRange.LowerBound += (difference / 2) + 1;
                    return numberRange;

                case 'R':
                    numberRange.LowerBound += (difference / 2) + 1;
                    return numberRange;

                case 'L':
                    numberRange.UpperBound = numberRange.UpperBound - (difference / 2) - 1;
                    return numberRange;

                default: return numberRange;
            }
        }
    }
}
