using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    class Slot
    {
        public Slot(Size s, int r, int c)
        {
            size = s;
            row = r;
            col = c;
        }
        public Size size { get; set; }

        public int row { get; set; }
        public int col { get; set; }

        public Vehicle vehicle { get; set; }
    }
}
