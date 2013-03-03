using System;
using System.Linq;
using DaysUntoWeb.Infrastructure.Entities;

namespace DaysUntoWeb.Migrations
{
    using System.Data.Entity.Migrations;
    using DDay.iCal;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Data.DaysUntoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private void SeedHolidays(string fileName, Infrastructure.Data.DaysUntoContext context, string country)
        {
            var calendars = iCalendar.LoadFromFile(fileName);
            var occurrences = calendars.GetOccurrences(new iCalDateTime(DateTime.Now.Year, 1, 1),
                                                       new iCalDateTime(DateTime.Now.Year, 12, 31))
                                       .Where(o => o.Period.StartTime.Year == DateTime.Now.Year);

            foreach (var occurrence in occurrences)
            {
                var rc = occurrence.Source as IRecurringComponent;
                if (rc != null)
                {
                    if (!rc.Summary.Contains("("))
                    {
                        context.Holidays.AddOrUpdate(
                            p => new { p.HolidayName, p.Country },
                            new Holiday
                            {
                                HolidayDate = occurrence.Period.StartTime.Local,
                                Country = country,
                                HolidayName = rc.Summary
                            }
                            );
                    }
                }
            }
        }

        protected override void Seed(Infrastructure.Data.DaysUntoContext context)
        {
            SeedHolidays(@"C:\Projects\DaysUntoWeb\DaysUntoWeb\Migrations\Seed_Data\USHolidays.ics", context, "US");
            SeedHolidays(@"C:\Projects\DaysUntoWeb\DaysUntoWeb\Migrations\Seed_Data\CanadaHolidays.ics", context, "CA");
            SeedHolidays(@"C:\Projects\DaysUntoWeb\DaysUntoWeb\Migrations\Seed_Data\UKHolidays.ics", context, "UK");

          
        }
    }
}
