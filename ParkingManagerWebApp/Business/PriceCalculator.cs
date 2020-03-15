using ParkingManagerWebApp.Models.Parking;
using System;

namespace ParkingManagerWebApp.Business
{
    public class PriceCalculator : IPriceCalculator
    {
        public double CalculateTotalValue(ParkingStayModel parkingStay)
        {
            if (parkingStay.Duration.TotalMinutes <= 30)
            {
                return parkingStay.CurrentPrice / 2;
            }
            else if (parkingStay.Duration.TotalMinutes > 30 && parkingStay.Duration.TotalMinutes <= 70)
            {
                return parkingStay.CurrentPrice;
            }
            else
            {
                var hoursToCalculate = parkingStay.Duration.Minutes <= 10 ? parkingStay.Duration.TotalHours : parkingStay.Duration.TotalHours - 1;
                return Math.Round(hoursToCalculate) * parkingStay.CurrentPrice;
            }
        }
    }
}
