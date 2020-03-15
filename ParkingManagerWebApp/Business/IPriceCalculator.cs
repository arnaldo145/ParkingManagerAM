using ParkingManagerWebApp.Models.Parking;

namespace ParkingManagerWebApp.Business
{
    public interface IPriceCalculator
    {
        double CalculateTotalValue(ParkingStayModel parkingStay);
    }
}
