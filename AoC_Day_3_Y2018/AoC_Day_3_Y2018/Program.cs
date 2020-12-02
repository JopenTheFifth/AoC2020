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
                var margin = parsed[2].Split(',');
                var dimensions = parsed[3].Split('x');


                var startFromLeft = int.Parse(margin[0]);
                var startFromTop = int.Parse(margin[1]);


                var width = dimensions[0];
                var height = dimensions[1];




                Buffer.BlockCopy(collection, startFromLeft, startFromTop )
                //encapsulate a part of the 2d array based on the start and end position
                // if its 10 inches from the left, and 20 in width, we can calculate the end point
                // in this case, 10 + 20 = 30.



                
               
            }

            //for (int i = 0; i < collection.GetLength(0); i++)
            //{
            //    Console.WriteLine(collection[i, 0] + " " + collection[i, 1]);
            //}

            Console.ReadLine();
        }



        public static char[,] CreateArray()
        {
            char[,] array = new char[1000, 1000];
            for (int i = 0; i < 1000 -1; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    array[i, j] = '.';
                }
            }
            return array;
        }
    }
}
