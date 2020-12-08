using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_8_part_1
{
    class Program
    {

        static int accumulator = 0;
        static int startIndex = 0;
        static List<string> pastInstructions = new List<string>();

        static Dictionary<string, int> instructionHistory = new Dictionary<string, int>();
        

        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_8_part_1\AoC_Day_8_part_1\inputs.txt");
            var outcome = myfile.ReadToEnd();
            var splitOnBreak = outcome.Split(new[] { Environment.NewLine, "\r" }, StringSplitOptions.None);
            int test = 0;




            //The moment the program tries to run any instruction a second time, you know it will never terminate
            //Immediately before the program would run an instruction a second time, the value in the accumulator is 5;
            //run your copy of the boot code, Immediately before any instruction is executed a second time, what value is in the accumulator?



            //logically, this means that if the same instruction is executed, while the instruction is @ the same index as the last time
            //THEN one would be stuck in a infinite loop.

            for (int i = startIndex; i < splitOnBreak.Length; i = test)
            {

                var operation = splitOnBreak[i].Substring(0, 3);
                var argument = splitOnBreak[i].Split(' ')[1];



                if (instructionHistory.ContainsKey(splitOnBreak[i]))
                {
                    Console.WriteLine($"key:{splitOnBreak[i]}  value:{instructionHistory[splitOnBreak[i]]} - actual index {i}");
                    Console.WriteLine(accumulator);
                    if (instructionHistory[splitOnBreak[i]] == i)
                    {
                        Console.WriteLine(accumulator);
                    }
                }



                test = Process(operation, argument);

                if (!instructionHistory.ContainsKey(splitOnBreak[i]))
                {
                    instructionHistory.Add(splitOnBreak[i], i);
                }
                
               
                
            }


            Console.WriteLine(accumulator);
            Console.ReadKey();
        }


        //handles the accumulator value, and gives the new index.
        public static int Process(string operation, string argument)
        {
            var oprt = argument[0];
            var value = int.Parse(argument.Split(oprt)[1]);

            switch (operation)
            {
                case "nop":
                    return startIndex += 1;
                case "acc":
                    if (oprt == '+')
                    {
                        accumulator += value;
                    }
                    else
                    {
                        accumulator -= value;

                    }
                    return startIndex += 1;
                case "jmp":
                    if(oprt == '+')
                    {
                        return startIndex += value;
                    }
                    else
                    {
                        return startIndex -= value;
                    }
                default: return 0;
            }
        }
    }
}
