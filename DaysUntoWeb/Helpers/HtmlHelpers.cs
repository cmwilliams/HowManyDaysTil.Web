using System;
using System.Globalization;
using System.Web.Mvc;

namespace DaysUntoWeb.Helpers
{
    public static class HtmlHelpers
    {
        public static string DisplayDaysLeft(this HtmlHelper helper, DateTime eventDate)
        {
            var ts = eventDate - DateTime.Today.Date;
            return ts.Days == 0 ? "Today's the day!" : String.Format("{0} days left", ts.Days);
        }

        public static string GetMonthName(this HtmlHelper helper, DateTime eventDate)
        {
            return eventDate.ToString("MMM", CultureInfo.InvariantCulture);
        }
    }
    
}