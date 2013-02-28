using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDay.iCal;
using DaysUntoWeb.Infrastructure.Data;
using DaysUntoWeb.Infrastructure.Entities;
using DaysUntoWeb.Models;
using WebMatrix.WebData;

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
            //Grab Country Events
            var holidays = _context.Holidays
                                   .Where(h => h.HolidayDate >= DateTime.Now && h.Country == "US")
                                   .OrderBy(h => h.HolidayDate)
                                   .Take(5)
                                   .ToList();
            var holiday = holidays.FirstOrDefault();
            var country = holiday == null ? "US" : holiday.Country;

            //Grab User Events
            var userEvents = new List<CalendarEvent>();
            var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
            if (user != null)
            {
                userEvents = user.CalendarEvents.OrderBy(c => c.CalendarEventDate).ToList();
            }

           

            var model = new HomeViewModel
                            {
                                Holidays = holidays,
                                Country = country,
                                CalendarEvents = userEvents
                            };

                return View(model);
           
        }


        [HttpPost]
        public ActionResult ImportCalendar(HttpPostedFileBase calendarfile)
        {
            if (calendarfile != null && calendarfile.ContentLength > 0)
            {
                var calendars = iCalendar.LoadFromStream(calendarfile.InputStream);
                var occurrences = calendars.GetOccurrences(new iCalDateTime(DateTime.Now.Year, 1, 1),
                                                           new iCalDateTime(2020, 12, 31));
                foreach (var occurrence in occurrences)
                {
                    var rc = occurrence.Source as IRecurringComponent;
                    if (rc != null)
                    {
                        var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
                        if (user != null)
                        {
                            var existingEvent = user.CalendarEvents.SingleOrDefault(c => c.CalendarEventDate == occurrence.Period.StartTime.Local && c.Name == rc.Summary);

                            if (existingEvent == null)
                            {
                                user.CalendarEvents.Add(new CalendarEvent { CalendarEventDate = occurrence.Period.StartTime.Local, Name = rc.Summary});
                            }
                        }

                        _context.SaveChanges();


                    }
                }
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");        
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
