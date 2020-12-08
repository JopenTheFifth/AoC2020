using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AoC_Day_7_part_1
{
    class Program
    {

        static List<Bag> Bags = new List<Bag>();
        static List<Bag> SampledBags = new List<Bag>();
        private static int counter = 0;

        static void Main(string[] args)
        {
            var myfile = new StreamReader(@"C:\Users\joelr\AoC2020\AoC_Day_7_part_1\AoC_Day_7_part_1\inputs.txt");
            var outcome = myfile.ReadToEnd();

           
            string[] splitOnGroup = outcome.Split('\n');

            for (int i = 0; i < splitOnGroup.Length; i++)
            {

                var wholeLine = splitOnGroup[i].Split(new[] { Environment.NewLine, "\r" }, StringSplitOptions.RemoveEmptyEntries);
                var bagName = wholeLine[0].Split(' ')[0] + " " + wholeLine[0].Split(' ')[1];

                //first fill all lines and add them as a new bag class.
                Bag bag = new Bag(bagName);


                string combined = "";
                foreach (var s in wholeLine)
                {
                    combined += s;
                }


                //Add innerBags if present.
                if (!combined.Contains("no"))
                {
                    //split the combined string up on 'Contain'
                    var parse = Regex.Split(combined, "contain");

                    //parse the inner bags (5 light violet bags, 1 light yelow bag)
                    var innerBags = parse[1];


                    //parse on ',' if present.
                    var parseInnerBags = innerBags.Split(',');

                    //foreach item in parseInnerBags, add to Bag's innerBag.
                    for (int j = 0; j < parseInnerBags.Length; j++)
                    {
                        var splitOnInnerBag = parseInnerBags[j].Split(' ');
                        var nameInnerBag = splitOnInnerBag[2] + " " + splitOnInnerBag[3];

                        Bag innerBag = new Bag(nameInnerBag);
                        bag.InnerBags.Add(innerBag);
                    }
                }
                Bags.Add(bag);
            }


            for (int i = 0; i < Bags.Count; i++)
            {
                SearchContent(Bags[i], Bags[i]);
            }
           
            
            Console.WriteLine(SampledBags.Count);
            Console.ReadKey();
        }

        
        public static Bag FindBagByName(string name)
        {
            return Bags.SingleOrDefault(x => x.Name == name);
        }




        public static void SearchContent(Bag initialBag, Bag rootBag)
        {
            //fuchsia
            Bag bag = initialBag;
            

            if(bag.InnerBags.Count == 0)
            {
                return;
            }


            for (int j = 0; j < bag.InnerBags.Count; j++)
            {
                // light violet, light yellow
                var innerbag = FindBagByName(bag.InnerBags[j].Name);

                if (innerbag.Name == "shiny gold")
                {
                    if (!SampledBags.Contains(rootBag))
                    {
                        SampledBags.Add(rootBag);
                    }
                }

                SearchContent(innerbag, rootBag);

            }
        }

    }
}
