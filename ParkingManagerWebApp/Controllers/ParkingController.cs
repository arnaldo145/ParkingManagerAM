using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingManagerWebApp.Business;
using ParkingManagerWebApp.Models;
using ParkingManagerWebApp.Models.Parking;
using ParkingManagerWebApp.Models.PriceControl;

namespace ParkingManagerWebApp.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ParkingManagerContext _context;
        private readonly IPriceCalculator _priceCalculator;

        public ParkingController(ParkingManagerContext context, IPriceCalculator priceCalculator)
        {
            _context = context;
            _priceCalculator = priceCalculator;
        }

        public IActionResult Index()
        {
            var model = _context.ParkingStayList.ToList();

            return View(model);
        }

        public IActionResult Entry()
        {
            var model = new ParkingEntryModel()
            {
                Entry = DateTime.Now
            };

            return View(model);
        }
        public IActionResult Exit(long id)
        {
            var parkingStay = _context.ParkingStayList.First(m => m.Id == id);

            if (parkingStay == null)
                return Redirect("Index");

            var model = new ParkingExitModel()
            {
                Id = parkingStay.Id,
                Entry = parkingStay.Entry,
                Exit = DateTime.Now,
                VehiclePlate = parkingStay.VehiclePlate
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterEntry(ParkingStayModel parkingEntry)
        {
            var parkingStay = new ParkingStayModel()
            {
                Entry = parkingEntry.Entry,
                VehiclePlate = parkingEntry.VehiclePlate
            };

            _context.ParkingStayList.Add(parkingStay);
            _context.SaveChanges();

            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult RegisterExit(ParkingExitModel parkingExit)
        {
            ParkingStayModel parkingStay = _context.ParkingStayList.First(m => m.Id == parkingExit.Id);

            if (parkingStay == null)
                return Redirect("Index");

            parkingStay.Exit = parkingExit.Exit;

            GetCurrentPricing(parkingStay);
            parkingStay.TotalValue = _priceCalculator.CalculateTotalValue(parkingStay);

            _context.Entry(parkingStay).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Payment", "Parking", new { id = parkingStay.Id });
        }

        public IActionResult Payment(long id)
        {
            ParkingStayModel model = _context.ParkingStayList.First(m => m.Id == id);

            if (model == null)
                return Redirect("Index");

            GetCurrentPricing(model);

            return View(model);
        }

        [NonAction]
        private void GetCurrentPricing(ParkingStayModel parkingStay)
        {
            PriceControlModel currentPrice = _context.PriceControlList.First(p => parkingStay.Entry.Date >= p.InitialDate.Date && parkingStay.Exit.Value.Date <= p.FinalDate.Date);

            if (currentPrice != null)
            {
                parkingStay.CurrentPrice = currentPrice.Price;
                parkingStay.CurrentAdditionalPrice = currentPrice.AdditionalPrice;
            }
        }
    }
}