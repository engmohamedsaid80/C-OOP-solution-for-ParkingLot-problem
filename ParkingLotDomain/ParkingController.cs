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
            bool result = false;

            if (vehicle.VehicleSize == Size.Med)
            {
                if(!medParking.ParkVehicle(vehicle,out ps))
                    if (!largeParking.ParkVehicle(vehicle, out ps))
                        if (!xLargeParking.ParkVehicle(vehicle, out ps))
                            result = false;
                        else
                            result = true;
            }
            else if (vehicle.VehicleSize == Size.Large)
            {
                if (!largeParking.ParkVehicle(vehicle, out ps))
                    if (!xLargeParking.ParkVehicle(vehicle, out ps))
                        result = false;
                    else
                        result = true;
            }
            else if (vehicle.VehicleSize == Size.XLarge)
            {
                if (!xLargeParking.ParkVehicle(vehicle, out ps))
                    result = false;
                else
                    result = true;
            }

            if (ps != null)
            {
                occupiedPS.Add(vehicle.PlateNum, ps);
            }

            return result;
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

        public Slot RemoveVehicle(string plate)
        {
            Slot slot = null;

            if (occupiedPS.ContainsKey(plate))
            {
                slot = occupiedPS[plate];

                occupiedPS.Remove(plate);

                AddEmptySlot(slot);
            }

            return slot;
        }
    }
}
