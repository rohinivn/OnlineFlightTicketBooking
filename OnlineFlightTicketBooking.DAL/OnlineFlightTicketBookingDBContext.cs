using OnlineFlightTicketBooking.Entity;
using System.Data.Entity;
namespace OnlineFlightTicketBooking.DAL
{
    public class OnlineFlightTicketBookingDBContext : DbContext
        {
            public DbSet<Account> Accounts { get; set; }
            public DbSet<Flight> Flights { get; set; }
            public DbSet<FlightClass> FlightClass { get; set; } 
            public DbSet<FlightClassDetail> FlightClassDetails { get; set; }
        }
}
