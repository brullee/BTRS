using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View(_context.busTrip.ToList());
        }

        // GET: BusTripController/Details/5
        public ActionResult Details(int id)
        {
            BusTrip trip = _context.busTrip.Find(id);
            return View(trip);
        }

        // GET: BusTripController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusTripController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusTrip trip)
        {

                int adminid = (int)HttpContext.Session.GetInt32("adminID");
                
                Admin admin = _context.admin.Where(
                  a => a.Id == adminid
                  ).FirstOrDefault();

                trip.admin = admin;

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
            BusTrip trip = _context.busTrip.Find(id);
            HttpContext.Session.SetInt32("busTripID", trip.TripId);

            return View(trip);
        }

        // POST: BusTripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BusTrip trip)
        {
            try
            {
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
            return View(trip);
        }

        // POST: BusTripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BusTrip trip)
        {
            try
            {
                _context.busTrip.Remove(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult AddBus()
        {
            return View();
        }


        

    }
}
