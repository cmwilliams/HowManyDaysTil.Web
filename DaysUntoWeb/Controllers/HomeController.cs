using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDay.iCal;
using DaysUntoWeb.Infrastructure.Data;
using DaysUntoWeb.Models;

namespace DaysUntoWeb.Controllers
{
    public class HomeController : Controller
    {
        private DaysUntoContext _context;

        public HomeController()
        {
            _context = new DaysUntoContext();
        }

        public ActionResult Index()
        {

            var holidays = _context.Holidays
                                   .Where(h => h.HolidayDate >= DateTime.Now && h.Country == "US")
                                   .OrderBy(h => h.HolidayDate)
                                   .Take(5)
                                   .ToList();

            var holiday = holidays.FirstOrDefault();
            var country = holiday == null ? "US" : holiday.Country;

            var model = new HomeViewModel
                            {
                                Holidays = holidays,
                                Country = country
                            };

                return View(model);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_context != null)
            {
             _context.Dispose();   
            }
            base.Dispose(disposing);
        }
    }
}
