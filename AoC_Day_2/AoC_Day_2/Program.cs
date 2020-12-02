using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader myfile = new StreamReader(@"D:\inputs/inputs.txt");
            var digits = myfile.ReadToEnd().Split('\n');
            var amount = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                var outcome = digits[i].Split(' ');
                var character = outcome[1].Trim(':');
                var count = outcome[2].Count(x => x == character[0]);
                var y = outcome[0];
                var numberRange  = y.Split('-');

                int number1 = int.Parse(numberRange[0]);
                int number2 = int.Parse(numberRange[1]);

                if (outcome[2][number1 - 1] == character[0] && outcome[2][number2 - 1] != character[0]
                    || outcome[2][number2 - 1] == character[0] && outcome[2][number1 - 1] != character[0])
                {
                    amount += 1;
                }  
            }
            Console.WriteLine(amount);
            Console.ReadKey();
        }
    }
}
