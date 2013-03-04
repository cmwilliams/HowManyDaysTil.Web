using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDay.iCal;
using DaysUntoWeb.Infrastructure.Data;
using DaysUntoWeb.Infrastructure.Entities;
using DaysUntoWeb.Models;
using WebMatrix.WebData;
using DaysUntoWeb.Helpers;


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
                                   .Where(h => h.HolidayDate >= DateTime.Today.Date && h.Country == "US")
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
                userEvents =
                    user.CalendarEvents
                        .Where(h => h.CalendarEventDate >= DateTime.Today.Date)
                        .OrderBy(c => c.CalendarEventDate)
                        .ToList();
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
            try
            {
                if (calendarfile != null && calendarfile.ContentLength > 0)
                {
                    var calendars = iCalendar.LoadFromStream(calendarfile.InputStream);
                    var occurrences = calendars.GetOccurrences(new iCalDateTime(DateTime.Now.Year, 1, 1),
                                                               new iCalDateTime(2020, 12, 31));
                    if (occurrences.Count == 0)
                    {
                        return RedirectToAction("Index").Warning("0 records were imported. Please double check your file and try again.");
                    }

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
                                    user.CalendarEvents.Add(new CalendarEvent { CalendarEventDate = occurrence.Period.StartTime.Local, Name = rc.Summary });
                                }
                            }

                            _context.SaveChanges();

                        }
                    }
                }
                return RedirectToAction("Index").Success("Your calendar was successfully imported!");
            }
            catch (Exception x)
            {

                return RedirectToAction("Index").Error("The following error occurred " + x.Message); 
            }
           
        }

        [HttpPost]
        public ActionResult ManualEntry(FormCollection form)
        {
            try
            {
                var eventName = form["calendarName"];
                var eventDate = form["calendarDate"];
                var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
                if (user != null)
                {
                    user.CalendarEvents.Add(new CalendarEvent
                    {
                        CalendarEventDate = Convert.ToDateTime(eventDate),
                        Name = eventName
                    });
                }

                _context.SaveChanges();

                return RedirectToAction("Index").Success(eventName + " was successfully added!");
               
            }
            catch (Exception x)
            {
               
                return RedirectToAction("Index").Error("The following error occurred " + x.Message); 
            }
           


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

        public PartialViewResult EditEvent(int id)
        {
            CalendarEvent calendarEvent = null;

             var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
            if (user != null)
            {
                calendarEvent = user.CalendarEvents.SingleOrDefault(c => c.CalendarEventId == id);
            }


            var model = new EditEventViewModel
                            {
                                CalendarEvent = calendarEvent
                            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditEvent(CalendarEvent calendarEvent)
        {
            var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
            if (user == null)
                return RedirectToAction("Index").Error("We couldn't find you. Please try logging in again.");


            var existingCalendarEvent = user.CalendarEvents.SingleOrDefault(c => c.CalendarEventId == calendarEvent.CalendarEventId);

            if (existingCalendarEvent == null)
                return RedirectToAction("Index").Error("We couldn't find this event. Please try again.");


            existingCalendarEvent.CalendarEventDate = calendarEvent.CalendarEventDate;
            existingCalendarEvent.Name = calendarEvent.Name;
            _context.SaveChanges();
            return RedirectToAction("Index").Success("Event was successfully updated!");

        }

        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
             var user = _context.UserProfiles.SingleOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
            if (user == null)
                return RedirectToAction("Index").Error("We couldn't find you. Please try logging in again.");

            var existingCalendarEvent = user.CalendarEvents.SingleOrDefault(c => c.CalendarEventId == id);

            if (existingCalendarEvent == null)
                return RedirectToAction("Index").Error("We couldn't find this event. Please try again.");

            _context.CalendarEvents.Remove(existingCalendarEvent);
            _context.SaveChanges();
            return RedirectToAction("Index").Success("Event was successfully deleted!");
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
