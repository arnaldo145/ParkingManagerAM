using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagerWebApp.Models.Parking
{
    public class ParkingEntryModel
    {
        [Required]
        [StringLength(8)]
        [Display(Name = "Placa do Veículo")]
        public string VehiclePlate { get; set; }

        [Display(Name = "Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime Entry { get; set; }
    }
}
