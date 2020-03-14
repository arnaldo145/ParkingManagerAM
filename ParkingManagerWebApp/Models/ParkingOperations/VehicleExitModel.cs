using System;

namespace ParkingManagerWebApp.Models.ParkingOperations
{
    public class VehicleExitModel
    {
        public long Id { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime OccurrenceDateTime { get; set; }
    }
}
