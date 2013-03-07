using System.Data.Entity;
using HowManyDaysTil.Web.Infrastructure.Entities;

namespace HowManyDaysTil.Web.Infrastructure.Data
{
    public class HowManyDaysTilContext : DbContext
    {
        public HowManyDaysTilContext()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}