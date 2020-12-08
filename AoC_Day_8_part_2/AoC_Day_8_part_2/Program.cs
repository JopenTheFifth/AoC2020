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


        static List<int> indexes = new List<int>();
        static Dictionary<string, int> instructionHistory = new Dictionary<string, int>();
        static Dictionary<string, int> resultedInInfiniteLoopAfterChange = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_8_part_2\AoC_Day_8_part_2\test.txt");
            var outcome = myfile.ReadToEnd();
            var splitOnBreak = outcome.Split(new[] { Environment.NewLine, "\r" }, StringSplitOptions.None);
            int test = 0;



            var index = 0;
            string instruction = "";
            string newOperation = "";
            
            for (int i = startIndex; i < splitOnBreak.Length; i = test)
            {

                var operation = splitOnBreak[i].Substring(0, 3);
                var argument = splitOnBreak[i].Split(' ')[1];

                //swap jmp operations with nop and vice versa.
               
                
                if(instruction == "" && !indexes.Contains(i))
                {
                    if (operation == "jmp" || operation == "nop")
                    {
                        instruction = operation;
                        index = i;
                        newOperation = operation == "jmp" ? "nop" : "jmp";
                        splitOnBreak[i] = splitOnBreak[i].Replace(operation, newOperation);
                        operation = newOperation;
                    }
                }


                if (instructionHistory.ContainsKey(splitOnBreak[i]))
                {
                    if (instructionHistory[splitOnBreak[i]] == i)
                    {
                        //Confirmed infinite loop

                        Console.WriteLine("confirmed infinite lewp");
                        //resultedInInfiniteLoopAfterChange.Add(splitOnBreak[i], i);

                        splitOnBreak[index] = splitOnBreak[index].Replace(newOperation, instruction);
                        indexes.Add(index);
                        instruction = "";
                        accumulator = 0;
                        instructionHistory.Clear();

                    }
                }

                Console.WriteLine(splitOnBreak[i]);


                 operation = splitOnBreak[i].Substring(0, 3);
                 argument = splitOnBreak[i].Split(' ')[1];

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
                    if (oprt == '+')
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
