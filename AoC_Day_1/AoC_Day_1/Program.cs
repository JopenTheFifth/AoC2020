using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AoC_D1
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader myfile = new StreamReader(@"C:\Users\joelr\source\repos\\AoC_D1\AoC_D1\data\numbers.txt");
            var numbers = myfile.ReadToEnd().Split('\n').Select(Int32.Parse).ToList();
            int total = 0;
            foreach (var t in numbers)
            {
                foreach (var t1 in numbers)
                {
                    foreach (var t2 in numbers)
                    {
                        if (t + t1 + t2 != 2020) continue;
                        total = 0;
                        total = (t * t1 * t2);
                    }
                }
            }
        }
    }
}
