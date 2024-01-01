using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace BTRS.Controllers
{
    public class PassengerController : Controller
    {
        private SystemDbContext _context;

        public PassengerController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: PassengerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Passenger user)
        {
            bool empty = checkEmpty(user);
            bool duplicate = duplicateEmail(user.Username);
            bool gender_valid = validGender(user.Gender);

            if (!empty)
            {
                if (!duplicate)
                {
                    if(!gender_valid)
                    {
                        TempData["Msg"] = "Gender is invalid";
                        return View();
                    }
                    _context.passenger.Add(user);
                    _context.SaveChanges();

                    TempData["Msg"] = "the data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username";
                    return View();
                }
     
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }

        }


        public bool duplicateEmail(string email)
        { 
            // checks if user is in the database, since emails are unique
            Passenger user = _context.passenger.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (user != null) // if user is found
            {
                return true;
            }
            return false;
        }

        public bool checkEmpty(Passenger user)
        {
            if (String.IsNullOrEmpty(user.Name)) return true;
            if (String.IsNullOrEmpty(user.Username)) return true;
            if (String.IsNullOrEmpty(user.PhoneNo)) return true;
            if (String.IsNullOrEmpty(user.Email)) return true;
            if(String.IsNullOrEmpty(user.Gender)) return true;
            return false;
        }

        public bool validGender(string gender)
        {
            List<string> validGenders = new List<string> { "male", "Male", "m", "Female", "female", "f" };
            return validGenders.Contains(gender);
        }

        public IActionResult TripList()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            List<int> BookedTrips = _context.passengers_trips
            .Where(t => t.passenger.PassengerId == userID).Select(t => t.trip.TripId).ToList();


            return View(BookedTrips);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                string username = userlogin.username;
                string password = userlogin.password;

                Passenger user = _context.passenger.Where(
                     u => u.Username.Equals(username) &&
                     u.password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a => a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (user != null)
                {
                    HttpContext.Session.SetInt32("PassengerID", user.PassengerId);

                    return RedirectToAction("TripList");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.Id);

                    return RedirectToAction("Index","BusTrip");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }

            }
            return View();
        }
    }
}
