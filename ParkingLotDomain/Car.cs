using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    class Car
    {
        public Car(Size s, string p)
        {
            size = s;
            PlateNum = p;
        }
        public Size size { get; set; }

        public string PlateNum { get; set; }
    }
}
