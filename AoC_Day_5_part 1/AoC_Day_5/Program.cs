using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_5
{
    class Program
    {
        //first 7 chars will be either F or B
        //these specific exactly 128 rows. (0-127)


        //For example, consider just the first seven characters of FBFBBFFRLR:

        //Start by considering the whole range, rows 0 through 127.
        //F means to take the lower half, keeping rows 0 through 63.
        //B means to take the upper half, keeping rows 32 through 63.
        //F means to take the lower half, keeping rows 32 through 47.
        //B means to take the upper half, keeping rows 40 through 47.
        //B keeps rows 44 through 47.
        //F keeps rows 44 through 45.
        //The final F keeps the lower of the two, row 44.

        //find the highest seat ID by:
        // row *8 + columnNumber
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
                    for (int k = 0; k < parsed[j].Length -3; k++)
                    {
                        //process the first 7 chars with ref numberSet1
                        ProcessData(parsed[j][k], ref NumberSet1);
                    }
                    for (int y = parsed[j].Length -3; y < parsed[j].Length ; y++)
                    {
                        //process the last 3 chars with ref numberSet2
                        ProcessData(parsed[j][y], ref NumberSet2);
                    }

                    var number = (NumberSet1.UpperBound * 8) + NumberSet2.LowerBound;
                    results.Add(number);
                }
            }
            Console.WriteLine(results.Max());
            Console.ReadKey();

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
