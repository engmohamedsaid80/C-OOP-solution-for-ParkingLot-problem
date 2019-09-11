using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    class Vehicle
    {
        public Vehicle(Size s, string p)
        {
            size = s;
            PlateNum = p;
        }
        public Size size { get; set; }

        public string PlateNum { get; set; }
    }
}
