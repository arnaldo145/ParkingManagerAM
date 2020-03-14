using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagerWebApp.Models.PriceControl
{
    public class PriceControlModel
    {
        public long Id { get; set; }

        [Display(Name = "Data Inicial")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Preço da Hora")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "Preço da Hora Adicional")]
        [Required]
        public double AdditionalPrice { get; set; }

        public bool IsCurrent
        {
            get
            {
                var now = DateTime.Now;
                return now.Date >= InitialDate.Date && now.Date <= FinalDate.Date;
            }
        }
    }
}
