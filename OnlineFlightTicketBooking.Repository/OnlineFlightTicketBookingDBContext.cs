using OnlineFlightTicketBooking.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightTicketBooking.Repository
{
    public class OnlineFlightTicketBookingDBContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
