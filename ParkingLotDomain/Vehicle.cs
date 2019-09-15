using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    public class VehicleFactory
    {
        public static Vehicle GetVehicleObject(Size s, string p)
        {
            Vehicle v = null;

            switch (s)
            {
                case (Size.Med): { v = new Car(p); break; }
                case (Size.Large): { v = new Truck(p); break; }
                case (Size.XLarge): { v = new Bus(p); break; }
            }

            return v;
        }
    }

    public abstract class Vehicle
    {
        public Vehicle(Size s, string p)
        {
            VehicleSize = s;
            PlateNum = p;
        }
        public Size VehicleSize { get; set; }

        public string PlateNum { get; set; }
    }

    public class Car : Vehicle
    {
        public Car(string p) : base(Size.Med,p)
        {
        }
    }

    public class Truck : Vehicle
    {
        public Truck(string p) : base(Size.Large, p)
        {
        }
    }

    public class Bus : Vehicle
    {
        public Bus(string p) : base(Size.XLarge, p)
        {
        }
    }
}
