using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_7_part_1
{
    public class InnerBag : Bag
    {

        public int Count { get; set; }
        public InnerBag(string pName) : base(pName)
        {

        }
    }
}
