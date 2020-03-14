using Microsoft.AspNetCore.Mvc;

namespace ParkingManagerWebApp.Controllers
{
    public class ParkingOperationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}