using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerWebApp.Models.Parking
{
    public class ParkingStayModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Placa do Veículo")]
        public string VehiclePlate { get; set; }

        [Display(Name = "Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime Entry { get; set; }

        [Display(Name = "Saída")]
        [DataType(DataType.DateTime)]
        public DateTime? Exit { get; set; }

        [Display(Name = "Valor Total")]
        public double TotalValue { get; set; }

        [Display(Name = "Duração")]
        [NotMapped]
        public TimeSpan Duration => Exit.HasValue ? Exit.Value - Entry : TimeSpan.Zero;

        [Display(Name = "Preço da hora")]
        [NotMapped]
        public double CurrentPrice { get; set; }

        [Display(Name = "Preço da hora adicional")]
        [NotMapped]
        public double CurrentAdditionalPrice { get; set; }
    }
}
