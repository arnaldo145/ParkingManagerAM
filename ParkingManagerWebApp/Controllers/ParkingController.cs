using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingManagerWebApp.Models;
using ParkingManagerWebApp.Models.Parking;

namespace ParkingManagerWebApp.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ParkingManagerContext _context;

        public ParkingController(ParkingManagerContext context)
        {
            _context = context;
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
            var parkingStay = _context.ParkingStayList.First(m => m.Id == parkingExit.Id);

            if (parkingStay == null)
                return Redirect("Index");

            parkingStay.Exit = parkingExit.Exit;

            _context.Entry(parkingStay).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Payment", "Parking");
        }

        public IActionResult Payment()
        {
            return View();
        }
    }
}