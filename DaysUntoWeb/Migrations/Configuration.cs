using System;
using System.Collections.Generic;
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

        protected override void Seed(Infrastructure.Data.DaysUntoContext context)
        {
            //Populate US Dates

            var calendars = iCalendar.LoadFromFile(@"C:\Projects\DaysUntoWeb\DaysUntoWeb\USHolidays.ics");
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
                                    Country = "US",
                                    HolidayName = rc.Summary
                                }
                            );
                    }
                }
            }

            //Populate CA Dates

            var caCalendars = iCalendar.LoadFromFile(@"C:\Projects\DaysUntoWeb\DaysUntoWeb\CanadaHolidays.ics");
            var caOccurrences = caCalendars.GetOccurrences(new iCalDateTime(DateTime.Now.Year, 1, 1),
                                                           new iCalDateTime(DateTime.Now.Year, 12, 31))
                                           .Where(o => o.Period.StartTime.Year == DateTime.Now.Year);

            foreach (var caOccurrence in caOccurrences)
            {
                var caRcc = caOccurrence.Source as IRecurringComponent;
                if (caRcc != null)
                {
                    if (!caRcc.Summary.Contains("("))
                    {
                        context.Holidays.AddOrUpdate(
                            p => new { p.HolidayName, p.Country },
                            new Holiday
                                {
                                    HolidayDate = caOccurrence.Period.StartTime.Local,
                                    Country = "CA",
                                    HolidayName = caRcc.Summary
                                }
                            );
                    }
                }
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
