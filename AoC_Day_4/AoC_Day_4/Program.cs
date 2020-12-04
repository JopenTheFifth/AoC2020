using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_Day_4
{
    class Program
    {

        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_4\AoC_Day_4\inputs.txt");
            var outcome = myfile.ReadToEnd();
            var parsedOutcome = myfile.ReadToEnd().Split('\n');


            string[] dataSetString = outcome.Split(new string[] { Environment.NewLine + Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);


            var counter = 0;
            for (int i = 0; i < dataSetString.Length; i++)
            {
                var test = dataSetString[i].Split(new []{Environment.NewLine, " "}, StringSplitOptions.None);

                bool condition = false;
                for (int j = 0; j < test.Length; j++)
                {
                    if (test[j].Contains("cid"))
                    {
                        condition = true;
                    }
                }


                if (test.Length == 8 || test.Length == 7 && !condition)
                {
                    var validationCounter = 0;
                    for (int j = 0; j < test.Length; j++)
                    {
                        var key = test[j].Split(':')[0];
                        var value = test[j].Split(':')[1];
                        if (Validate(key, value))
                        {
                            validationCounter++;
                        }
                    }
                    if(validationCounter == test.Length)
                    {
                        counter++;
                        
                    }
                }
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }

        public static bool Validate(string pKey, string pValue)
        {
            switch (pKey)
            {
                case "byr":
                {
                    var parsedToYear = int.Parse(pValue);
                    return pValue.Length == 4 && (parsedToYear >= 1920 && parsedToYear <= 2002);
                }
                case "iyr":
                {
                    var parsedToYear = int.Parse(pValue);
                    return pValue.Length == 4 && (parsedToYear >= 2010 && parsedToYear <= 2020);

                }
                case "eyr":
                {
                    var parsedToYear = int.Parse(pValue);
                    return pValue.Length == 4 && (parsedToYear >= 2020 && parsedToYear <= 2030);

                }
                case "hgt":
                {
                    if (pValue.EndsWith("cm"))
                    {
                        var trimmed = pValue.Remove(pValue.Length - 2, 2);
                        if(int.Parse(trimmed) >= 150 && int.Parse(trimmed) <= 193)
                        {
                            return true;
                        }
                    }
                    else if( pValue.EndsWith("in"))
                    {
                        var trimmed = pValue.Remove(pValue.Length - 2, 2);
                        if (int.Parse(trimmed) >= 59 && int.Parse(trimmed) <= 76)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                case "hcl":
                {
                    Regex regex = new Regex("^[#][0-9a-f]{1,6}");
                    return regex.IsMatch(pValue);

                    }
                case "ecl":
                {
                    return pValue == "amb" || pValue == "blu" || pValue == "brn" || pValue == "gry"
                           || pValue == "grn" || pValue == "hzl" || pValue == "oth";
                }
                case "pid":
                {
                    return pValue.Length == 9;
                }
                case "cid":
                {
                    return true;
                }

                default: return false;
            }
        }
    }
}
