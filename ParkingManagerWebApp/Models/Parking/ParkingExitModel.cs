using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagerWebApp.Models.Parking
{
    public class ParkingExitModel
    {
        public long Id { get; set; }

        public string VehiclePlate { get; set; }

        public DateTime Entry { get; set; }

        [Display(Name = "Saída")]
        [DataType(DataType.DateTime)]
        public DateTime Exit { get; set; }
    }
}
