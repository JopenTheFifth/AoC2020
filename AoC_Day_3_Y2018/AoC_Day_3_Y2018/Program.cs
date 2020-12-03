using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_3_Y2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = CreateArray();

            StreamReader myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_3_Y2018\AoC_Day_3_Y2018/inputs.txt");
            var onBreak = myfile.ReadToEnd().Split('\n');
            


            int counter = 0;
            for (int i = 0; i < onBreak.Length; i++)
            {
                var parsed = onBreak[i].Split(' ');
                var claimId = parsed[0];
                var margin = parsed[2].Trim(':').Split(',');
                var dimensions = parsed[3].Split('x');


                var startFromLeft = int.Parse(margin[0]);
                var startFromTop = int.Parse(margin[1]);


                var width = dimensions[0];
                var height = dimensions[1];


                collection[startFromLeft, startFromTop] = $"{claimId}";

            }



            for (int i = 0; i < collection.Length; i++)
            {
                for (int j = 0; j < collection.Length; j +=2)
                {
                    Console.WriteLine($"{collection[i, j]}, {collection[i, j]}");
                }
            }

            Console.ReadLine();
        }



        public static string[,] CreateArray()
        {
            string[,] array = new string[1000, 1000];
            for (int i = 0; i < 1000 -1; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    array[i, j] = ".";
                }
            }
            return array;
        }
    }
}
