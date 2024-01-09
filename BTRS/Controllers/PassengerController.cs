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
                    if (!gender_valid)
                    {
                        TempData["Msg"] = "Gender is invalid";
                        return View();
                    }
             
                    _context.passenger.Add(user);
                    _context.SaveChanges();

                    HttpContext.Session.SetInt32("PassengerID", user.PassengerId);

                    return RedirectToAction("TripList");
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
            int userID = (int)HttpContext.Session.GetInt32("PassengerID");
    
            if(userID != null)
            {
                List<BusTrip> BookedTrips = _context.passengers_trips
            .Where(t => t.passenger.PassengerId == userID).Select(t => t.trip).ToList();

                return View(BookedTrips);
            }
            else
            {
                TempData["Msg"] = "The user Not Found";
                return View();
            }
            
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
            else
            {
                TempData["Msg"] = "The user Not Found";
            }
            return View();
        }

        public IActionResult TripDetails(int id)
        {
            BusTrip trip = _context.busTrip.Find(id);
            return View(trip);
        }

        public IActionResult ViewTrips()
        {
            List<BusTrip> availableTrips = _context.busTrip.ToList();
            return View(availableTrips);
        }

        public IActionResult AddTrip(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTrip");
            }

            int passengerID = (int)HttpContext.Session.GetInt32("PassengerID");
            BusTrip trip = _context.busTrip.Find(id);

            passengers_trips checkUnique = _context.passengers_trips.Where
            (t => t.passenger.PassengerId == passengerID && t.trip == trip)
           .FirstOrDefault(); 
            
            //Checking if the trip is already booked.

            if (checkUnique == null)
            {
                Passenger passenger = _context.passenger.Find(passengerID);

                passengers_trips passenger_trip = new passengers_trips();
                passenger_trip.trip = trip;
                passenger_trip.passenger = passenger;

                _context.passengers_trips.Add(passenger_trip);
                _context.SaveChanges();
            }
                  
            return RedirectToAction("AddTrip");
        }

        public IActionResult RemoveTrip(int id)
        {
            int passengerID = (int)HttpContext.Session.GetInt32("PassengerID");
            BusTrip trip = _context.busTrip.Find(id);

            passengers_trips passenger_trip = _context.passengers_trips
            .FirstOrDefault(t => t.passenger.PassengerId == passengerID && t.trip.TripId == trip.TripId);

            if (passenger_trip != null)
            {
                _context.passengers_trips.Remove(passenger_trip);
                _context.SaveChanges();
            }

            return RedirectToAction("TripList");
        }
    }
}
