using ParkingLotDomain;
using System;

namespace ParkingLotTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = ParkingLot.Instance;

            parkingLot.AddParkingSlot(Size.Med, 0, 0);
            parkingLot.AddParkingSlot(Size.Med, 1, 0);
            parkingLot.AddParkingSlot(Size.Med, 2, 0);

            parkingLot.AddParkingSlot(Size.Large, 0, 1);
            parkingLot.AddParkingSlot(Size.Large, 1, 1);
            parkingLot.AddParkingSlot(Size.Large, 2, 1);

            parkingLot.AddParkingSlot(Size.XLarge, 0, 2);
            parkingLot.AddParkingSlot(Size.XLarge, 1, 2);
            parkingLot.AddParkingSlot(Size.XLarge, 2, 2);

            string[] cars = { "123 ABC", "124 ABC", "125 ABC", "126 ABC"
                             ,"456 BCD", "457 BCD", "458 BCD"
                             ,"789 EFG", "788 EFG", "787 EFG"};
            Size[] carSizes = { Size.Med, Size.Med, Size.Med, Size.Med ,
                                Size.Large, Size.Large, Size.Large ,
                                Size.XLarge, Size.XLarge, Size.XLarge};

            for(int i =0; i< cars.Length; i++) parkingLot.ParkCar(carSizes[i], cars[i]);

            for (int i = 0; i < cars.Length; i++)
            {
                int r = 0, c = 0;
                parkingLot.GetCar(cars[i], out r, out c);
                Console.WriteLine("Car " + cars[i] + " was at row:" + r + " , col:" + c + 
                                  " - car Size:" + carSizes[i].ToString());
            }

        }
    }
}
