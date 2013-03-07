using System;
using System.Data.Entity.Migrations;
using DDay.iCal;
using HowManyDaysTil.Web.Infrastructure.Entities;

namespace HowManyDaysTil.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Data.HowManyDaysTilContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private static void SeedHolidays(string fileName, Infrastructure.Data.HowManyDaysTilContext context, string country, int endYear)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "\\Migrations\\Seed_Data\\" + fileName;

            var calendars = iCalendar.LoadFromFile(path);
            var occurrences = calendars.GetOccurrences(new iCalDateTime(DateTime.Now.Year, 1, 1),
                                                       new iCalDateTime(endYear, 12, 31));

            foreach (var occurrence in occurrences)
            {
                var rc = occurrence.Source as IRecurringComponent;
                if (rc != null)
                {
                    if (!rc.Summary.Contains("("))
                    {
                        context.Holidays.AddOrUpdate(
                            p => new { p.HolidayName, p.Country, p.HolidayDate },
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

        protected override void Seed(Infrastructure.Data.HowManyDaysTilContext context)
        {
            SeedHolidays("USHolidays.ics", context, "US", 2020);
            SeedHolidays("CanadaHolidays.ics", context, "CA", 2020);
            SeedHolidays("UKHolidays.ics", context, "UK", 2020);

          
        }
    }
}
