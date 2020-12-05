using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_5
{
    public class MyTuple
    {

        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public MyTuple(int plowerBound, int pUpperBound)
        {
            LowerBound = plowerBound;
            UpperBound = pUpperBound;
        }
    }
}
