using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_7_part_1
{
    public class Bag
    {

        public string Name { get; set; }
        public bool CanHoldShinyGoldenBag { get; set; }
        public List<Bag> InnerBags { get; set; }


        public Bag(string pName)
        {
            InnerBags = new List<Bag>();
            Name = pName;
            CanHoldShinyGoldenBag = false;
        }

      
        public bool IsShinyGolden()
        {
            return Name == "shiny gold";
        }



    }
}