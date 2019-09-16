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

        public bool ParkVehicle(Vehicle vehicle, out Slot ps)
        {
            ps = null;

            if (ParkingSlots.Count > 0)
            {
                ps = ParkingSlots[0];
                ParkingSlots.Remove(ps);

                ps.vehicle = vehicle;

                return true;
            }

            return false;
        }
    }
}
