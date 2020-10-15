using OnlineFlightTicketBooking.Entity;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightTicketBooking.DAL
{
    public interface IAccountRepository
    {
        void AddUser(Account user);
        Account ValidateUser(Account account);
        Account GetUser(int id);
        void UpdateProfile(Account account);
    }
    public class AccountRepository:IAccountRepository
    {
        public void AddUser(Account user)
        {
            using (OnlineFlightTicketBookingDBContext accountDBContext = new OnlineFlightTicketBookingDBContext())
            {

                accountDBContext.Accounts.Add(user);
                accountDBContext.SaveChanges();
            }
        }
        public Account ValidateUser(Account account)
        {
            using (OnlineFlightTicketBookingDBContext accountDBContext = new OnlineFlightTicketBookingDBContext())
            {
                var result = accountDBContext.Accounts.Where(user => user.EmailId == account.EmailId && user.Password == account.Password).FirstOrDefault();
                return result;
            }
        }
        public Account GetUser(int id)
        {
            using (OnlineFlightTicketBookingDBContext DBContext = new OnlineFlightTicketBookingDBContext())
            {
                return DBContext.Accounts.Where(user => user.Id==id).FirstOrDefault();
                string str = "Comit";
                char c= str.

            }
        }

        public void UpdateProfile(Account account)
        {
            using (OnlineFlightTicketBookingDBContext DBContext = new OnlineFlightTicketBookingDBContext())
            {
                DBContext.Entry(account).State = EntityState.Modified;
                DBContext.SaveChanges();
            }
        }
        //public Account GetUserByCredentials(string email,string password)
        //{
        //    using(OnlineFlightTicketBookingDBContext DBContext = new OnlineFlightTicketBookingDBContext())
        //    {
        //        return DBContext.Accounts.Where(user => user.EmailId==email&&user.Password==password).FirstOrDefault();
        //    }
        //}
    }
}
