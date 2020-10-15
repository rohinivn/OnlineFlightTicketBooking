namespace OnlineFlightTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineFlightTicketBooking.DAL.OnlineFlightTicketBookingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineFlightTicketBooking.DAL.OnlineFlightTicketBookingDBContext";
        }

        protected override void Seed(OnlineFlightTicketBooking.DAL.OnlineFlightTicketBookingDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
