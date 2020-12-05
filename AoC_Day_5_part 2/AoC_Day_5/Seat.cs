using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_5
{
    class Seat
    {

        public int Row { get; set; }
        public int SeatNumber { get; set; }


        public Seat(int row, int seatNr)
        {
            Row = row;
            SeatNumber = seatNr;
        }
    }
}
