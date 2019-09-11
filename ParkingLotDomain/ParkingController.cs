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

        public bool ParkCar(Car car)
        {
            Slot ps = null;

            if (car.size == Size.Med)
            {
                ps = medParking.ParkCar(car);

                if (ps == null)
                {
                    ps = largeParking.ParkCar(car);

                    if(ps == null)
                    {
                        ps = xLargeParking.ParkCar(car);
                    }
                }
            }
            else if (car.size == Size.Large)
            {
                ps = largeParking.ParkCar(car);

                if (ps == null)
                {
                    ps = xLargeParking.ParkCar(car);
                }
            }
            else if (car.size == Size.XLarge)
            {
                ps = xLargeParking.ParkCar(car);
            }

            if (ps != null)
            {
                occupiedPS.Add(car.PlateNum, ps);
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

        public Slot GetCar(string plate)
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
