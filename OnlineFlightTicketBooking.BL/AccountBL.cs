using OnlineFlightTicketBooking.Entity;
using OnlineFlightTicketBooking.DAL;
namespace OnlineFlightTicketBooking.BL
{
    public interface IAccountBL
    {
        void SignUp(Account user);
        Account ValidateUser(Account account);
        Account GetUser(int id);
        void UpdateProfile(Account account);
        //Account GetUserByCredentials(string email, string password);
    }
    public class AccountBL:IAccountBL
    {
        IAccountRepository accountRepository = new AccountRepository();

        public void SignUp(Account user)
        {
            accountRepository.AddUser(user);
        }
        public Account ValidateUser(Account account)
        {
            return accountRepository.ValidateUser(account);
        }
        public Account GetUser(int id)
        {
            return accountRepository.GetUser(id);
        }
        public void UpdateProfile(Account account)
        {
            accountRepository.UpdateProfile(account);
        }
        //public Account GetUserByCredentials(string email,string password)
        //{
        //    return accountRepository.GetUserByCredentials(email, password);
        //}
    }
}
