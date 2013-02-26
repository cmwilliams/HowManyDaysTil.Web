using System.Data.Entity;
using DaysUntoWeb.Infrastructure.Entities;

namespace DaysUntoWeb.Infrastructure.Data
{
    public class DaysUntoContext : DbContext
    {
        public DaysUntoContext()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}