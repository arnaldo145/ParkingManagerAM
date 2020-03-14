using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagerWebApp.Models;
using ParkingManagerWebApp.Models.Home;

namespace ParkingManagerWebApp.Controllers
{
    public class HomeController : Controller
    {
       private readonly ParkingManagerContext _context;

        public HomeController(ParkingManagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeModel();
            model.HasPrices = _context.PriceControlList.Count() > 0;
            
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
