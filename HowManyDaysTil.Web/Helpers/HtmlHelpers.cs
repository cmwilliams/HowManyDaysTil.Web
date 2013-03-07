using System;
using System.Globalization;
using System.Web.Mvc;

namespace HowManyDaysTil.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static string DisplayDaysLeft(this HtmlHelper helper, DateTime eventDate)
        {
            var ts = eventDate - DateTime.Today.Date;
            switch (ts.Days)
            {
                case 0:
                    return "Today's the day!";
                case 1:
                    return "1 day left";
                default:
                    return String.Format("{0} days left", ts.Days);
            }

        }

        public static string GetMonthName(this HtmlHelper helper, DateTime eventDate)
        {
            return eventDate.ToString("MMM", CultureInfo.InvariantCulture);
        }

       
    }
    
}