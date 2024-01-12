using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BTRS.Controllers
{
    public class BusController : Controller
    {
        private SystemDbContext _context;

        public BusController(SystemDbContext context)
        {
            this._context = context;
        }
        public ActionResult Index()
        {
            return View(_context.bus.ToList());
        }
        public ActionResult Details(int id)
        {
            Bus bus = _context.bus.Find(id);
            return View(bus);
        }

        public ActionResult Edit(int id)
        {
            Bus bus = _context.bus.Find(id);
            return View(bus);
        }

        // POST: BusTripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Bus bus)
        {
            try
            {
                _context.bus.Update(bus);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Bus bus = _context.bus.Include(b => b.trips).FirstOrDefault(b => b.BusId == id);

            if (bus == null)
            {
                return NotFound();
            }

            if (bus.trips != null && bus.trips.Count > 0)
            {
                TempData["msg"] = "Cannot remove a bus when it is assigned to a trip";
            }
            else
            {
                _context.bus.Remove(bus);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Bus bus)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(bus);
            }
        }

        [HttpGet]
        public IActionResult CreateBus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBus(Bus bus)
        {
            if (checkEmpty(bus) || bus.NOofSeats <= 0)
            {
                TempData["Msg"] = "Please fill all inputs and provide a valid number of seats.";
                return View();
            }
            else
            {
                

                _context.bus.Add(bus);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
        }

        public bool checkEmpty(Bus bus)
        {
            if (String.IsNullOrEmpty(bus.CptName)) return true;

            return false;
        }
    }
}
