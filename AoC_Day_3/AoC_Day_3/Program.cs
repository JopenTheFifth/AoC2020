using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\joelr\AoC2020\AoC_Day_3\AoC_Day_3\inputs.txt");
            var width = lines[0].Length; //31
            var height = lines.Length; // 323

            char[,] map = new char[height, width];
            
            for (int i = 0; i < height; i++)
            {
                var data = lines[i];


                for (int j = 0; j < width; j++)
                {
                    map[i, j] = data[j];
                }
            }

            //214, 94, 99, 91, 46

            var widthPos = 0;
            var heightPos = 0;
            var counter1 = 0;
            for (int i = 0; i < height; i++)
            {

                if (widthPos > 30)
                {
                    widthPos -= 31;
                }

                if (map[heightPos, widthPos] == '#')
                {
                    counter1 += 1;
                }

                widthPos += 3;
                heightPos += 1;

            }
            Console.WriteLine(counter1);
            Console.ReadKey();

        }
    }
}
