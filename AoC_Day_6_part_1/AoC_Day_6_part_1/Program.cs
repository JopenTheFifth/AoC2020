using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AoC_Day_6_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_6_part_1\AoC_Day_6_part_1\inputs.txt");
            var outcome = myfile.ReadToEnd();
            string[] SplittedOnGroup = outcome.Split(new string[] { Environment.NewLine + Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            var totalCounter = 0;


            
            //450 entries
            for (int i = 0; i < SplittedOnGroup.Length; i++)
            {
                //remove /r and /n's.
                var SplittedOnBreak = SplittedOnGroup[i].Split(new[] { Environment.NewLine, " " }, StringSplitOptions.None);




                //add back together in 1 string.
                string grouped = "";
                foreach (var s in SplittedOnBreak)
                {
                    grouped += s;
                }


                //find count of unique chars in dataGroup
                var uniqueCharCount = grouped.Distinct().Count();

                //find all unique chars per dataGroup
                var uniqueCharacters = grouped.Distinct().ToList();



                //foreach character in the uniqueCharacters list.
                for (int j = 0; j < uniqueCharacters.Count; j++)
                {

                    var counter = 0;

                   
                    for (int k = 0; k < SplittedOnBreak.Length; k++)
                    {
                       
                        if (SplittedOnBreak[k].Contains(uniqueCharacters[j]))
                        {
                            counter++;
                        }
                    }

                    if(counter == SplittedOnBreak.Length)
                    {
                        totalCounter++;
                    }
                }


               




            }

            Console.WriteLine(totalCounter);
            Console.ReadKey();

        }
        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
