using System.Data.Entity;
using HowManyDaysTil.Web.Infrastructure.Entities;
using HowManyDaysTil.Web.Migrations;

namespace HowManyDaysTil.Web.Infrastructure.Data
{
    public class HowManyDaysTilContext : DbContext
    {
        public HowManyDaysTilContext()
            : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HowManyDaysTilContext, Configuration>());
        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}