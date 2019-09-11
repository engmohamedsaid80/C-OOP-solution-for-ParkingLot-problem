using System;
using System.Collections.Generic;

namespace ParkingLotDomain
{
    

    public class ParkingLot
    {
        

        private static ParkingLot _instance;
        private ParkingController _parkingController;

        public static ParkingLot Instance
        {
            get
            {
                if (_instance == null) _instance = new ParkingLot();

                return _instance;
            }
        }

        private ParkingLot()
        {
            _parkingController = new ParkingController();
        }

        public void AddParkingSlot(Size s, int r, int c)
        {
            Slot slot = new Slot(s, r, c);

            _parkingController.AddEmptySlot(slot);

        }

        public bool ParkCar(Size s, string p)
        {
            Car car = new Car(s, p);

            return _parkingController.ParkCar(car);
        }

        public void GetCar(string plate, out int r, out int c)
        {
            r = -1; c = -1;

            var slot = _parkingController.GetCar(plate);

            if (slot != null)
            {
                r = slot.row; c = slot.col;
            }
        }
    }
}
