using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                int adminid = (int)HttpContext.Session.GetInt32("adminID");
                
                Admin admin = _context.admin.Where(
                  a => a.Id == adminid
                  ).FirstOrDefault();

                _context.busTrip.Add(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusTripController/Edit/5
        public ActionResult Edit(int id)
        {
            BusTrip trip = _context.busTrip.Find(id);
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
    }
}
