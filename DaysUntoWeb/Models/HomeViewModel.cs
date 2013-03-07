using System.Collections.Generic;
using HowManyDaysTil.Web.Infrastructure.Entities;

namespace HowManyDaysTil.Web.Models
{
    public class HomeViewModel
    {
        public IList<Holiday> Holidays { get; set; }
        public IList<CalendarEvent> CalendarEvents { get; set; }
        public string Country { get; set; }
    }
}