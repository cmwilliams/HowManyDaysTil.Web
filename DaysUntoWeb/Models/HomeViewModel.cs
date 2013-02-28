using System.Collections.Generic;
using DaysUntoWeb.Infrastructure.Entities;

namespace DaysUntoWeb.Models
{
    public class HomeViewModel
    {
        public IList<Holiday> Holidays { get; set; }
        public IList<CalendarEvent> CalendarEvents { get; set; }
        public string Country { get; set; }
    }
}