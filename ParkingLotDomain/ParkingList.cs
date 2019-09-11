using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotDomain
{
    class ParkingList
    {
        private List<Slot> ParkingSlots;

        public ParkingList()
        {
            ParkingSlots = new List<Slot>();
        }

        public void AddSlot(Slot s)
        {
            ParkingSlots.Add(s);
        }

        public Slot ParkVehicle(Vehicle vehicle)
        {
            Slot ps = null;

            if (ParkingSlots.Count > 0)
            {
                ps = ParkingSlots[0];
                ParkingSlots.Remove(ps);

                ps.vehicle = vehicle;
            }

            return ps;
        }
    }
}
