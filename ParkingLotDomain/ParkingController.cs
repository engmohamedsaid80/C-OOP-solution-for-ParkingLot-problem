using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    public enum Size { Med, Large, XLarge };

    class ParkingController
    {
        private ParkingList medParking;
        private ParkingList largeParking;
        private ParkingList xLargeParking;

        private Dictionary<string, Slot> occupiedPS;

        public ParkingController()
        {
            medParking = new ParkingList();
            largeParking = new ParkingList();
            xLargeParking = new ParkingList();

            occupiedPS = new Dictionary<string, Slot>();
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            Slot ps = null;

            if (vehicle.size == Size.Med)
            {
                ps = medParking.ParkVehicle(vehicle);

                if (ps == null)
                {
                    ps = largeParking.ParkVehicle(vehicle);

                    if(ps == null)
                    {
                        ps = xLargeParking.ParkVehicle(vehicle);
                    }
                }
            }
            else if (vehicle.size == Size.Large)
            {
                ps = largeParking.ParkVehicle(vehicle);

                if (ps == null)
                {
                    ps = xLargeParking.ParkVehicle(vehicle);
                }
            }
            else if (vehicle.size == Size.XLarge)
            {
                ps = xLargeParking.ParkVehicle(vehicle);
            }

            if (ps != null)
            {
                occupiedPS.Add(vehicle.PlateNum, ps);
                return true;
            }

            return false;
        }

        public void AddEmptySlot(Slot s)
        {
            switch (s.size)
            {
                case Size.Med:
                    {
                        medParking.AddSlot(s);
                        break;
                    }
                case Size.Large:
                    {
                        largeParking.AddSlot(s);
                        break;
                    }
                case Size.XLarge:
                    {
                        xLargeParking.AddSlot(s);
                        break;
                    }
            }
        }

        public Slot GetVehicle(string plate)
        {
            Slot slot = null;

            if (occupiedPS.ContainsKey(plate))
            {
                slot = occupiedPS[plate];

                AddEmptySlot(slot);
            }

            return slot;
        }
    }
}
