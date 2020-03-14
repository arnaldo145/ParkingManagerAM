using Microsoft.AspNetCore.Mvc;
using ParkingManagerWebApp.Models;
using ParkingManagerWebApp.Models.PriceControl;
using System.Collections.Generic;
using System.Linq;

namespace ParkingManagerWebApp.Controllers
{
    public class PriceControlController : Controller
    {
        private readonly ParkingManagerContext _context;

        public PriceControlController(ParkingManagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<PriceControlModel> model = _context.PriceControlList
                .OrderByDescending(m => m.FinalDate)
                .ToList();

            return View(model);
        }

        public IActionResult NewPrice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPrice(PriceControlModel priceControl)
        {
            _context.PriceControlList.Add(priceControl);
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}