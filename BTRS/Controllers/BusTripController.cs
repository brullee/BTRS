using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BTRS.Controllers
{
    public class BusTripController : Controller
    {
        private SystemDbContext _context;

        public BusTripController(SystemDbContext context)
        {
            this._context = context;
        }

        // GET: BusTripController
        public ActionResult Index()
        {
            return View(_context.busTrip.Include(bt => bt.bus).ToList());
        }

        // GET: BusTripController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.bus = _context.busTrip.Include(bt => bt.bus).ToList();
            BusTrip trip = _context.busTrip.Find(id);
            return View(trip);
        }

        // GET: BusTripController/Create
        public ActionResult Create()
        {
            ViewBag.bus = _context.bus.ToList();

            return View();
        }

        // POST: BusTripController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection form)
        {

            int adminid = (int)HttpContext.Session.GetInt32("adminID");
            int busid = int.Parse(form["busId"]);
            string destination = form["Destination"];
            DateTime startdate = DateTime.Parse(form["StartDate"]);
            DateTime enddate = DateTime.Parse(form["EndDate"]);

            if(busid == null)
            {
                TempData["msg"] = "No bus found";
            }

            Admin admin = _context.admin.Where(
              a => a.Id == adminid
              ).FirstOrDefault();


            BusTrip trip = new BusTrip();

            trip.admin = admin;
            trip.Destination = destination;
            trip.StartDate = startdate;
            trip.EndDate = enddate;
            trip.bus = _context.bus.Find(busid);

            if (trip.StartDate > trip.EndDate)
            {
                TempData["msg"] = "Start date is less than the end date.";
            }

            if (string.IsNullOrEmpty(trip.Destination))
            {
                ModelState.AddModelError("Destination", "Destination is required");
                return View(trip);
            }

            _context.busTrip.Add(trip);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: BusTripController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.bus = _context.bus.ToList();
            BusTrip trip = _context.busTrip.Find(id);
            HttpContext.Session.SetInt32("busTripID", trip.TripId);

            return View(trip);
        }

        // POST: BusTripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormCollection form)
        {
            try
            {
                int adminid = (int)HttpContext.Session.GetInt32("adminID");
                int tripID = int.Parse(form["TripID"]);
                int busid = int.Parse(form["busId"]);
                string destination = form["Destination"];
                DateTime startdate = DateTime.Parse(form["StartDate"]);
                DateTime enddate = DateTime.Parse(form["EndDate"]);

                if (busid == null)
                {
                    TempData["msg"] = "No bus found";
                }

                Admin admin = _context.admin.Where(
                  a => a.Id == adminid
                  ).FirstOrDefault();


                BusTrip trip = _context.busTrip.Find(tripID);

                trip.admin = admin;
                trip.Destination = destination;
                trip.StartDate = startdate;
                trip.EndDate = enddate;
                trip.bus = _context.bus.Find(busid);

                if (trip.StartDate > trip.EndDate)
                {
                    TempData["msg"] = "Start date is less than the end date.";
                }

                if (string.IsNullOrEmpty(trip.Destination))
                {
                    ModelState.AddModelError("Destination", "Destination is required");
                    return View(trip);
                }
                _context.busTrip.Update(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusTripController/Delete/5
        public ActionResult Delete(int id)
        {
            BusTrip trip = _context.busTrip.Find(id);
            _context.busTrip.Remove(trip);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: BusTripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BusTrip trip)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(trip);
            }
        }

       
    }
}
