using OnlineFlightTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightTicketBooking.Repository
{
    class AccountRepository
    {
        public void SignUp(Account user)
        {
            using(OnlineFlightTicketBookingDBContext accountDBContext =new OnlineFlightTicketBookingDBContext())
            {
                accountDBContext.Accounts
            }
        }
    }
}
