using System;
using System.Web.Security;
using AutoMapper;
using OnlineFlightTicketBooking.Entity;
using System.Web.Mvc;
using OnlineFlightTicketBooking.Models;
using OnlineFlightTicketBooking.BL;
using System.Web;
using ExceptionFilterInMVC.Models;

namespace OnlineFlightTicketBooking.Controllers
{
    [LogCustomExceptionFilter]
    public class AccountController : Controller
    {
        IAccountBL accountBLayer;
        public AccountController()
        {
            accountBLayer = new AccountBL();
        }
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        { 
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<SignUpViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                Account account = mapper.Map<SignUpViewModel, Account>(signUpViewModel);
                account.PhoneNumber = long.Parse(signUpViewModel.PhoneNumber);
                account.Role = "user";
                accountBLayer.SignUp(account);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<LoginViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var account = mapper.Map<LoginViewModel, Account>(loginViewModel);
                Account accountDetails = accountBLayer.ValidateUser(account);
                if (accountDetails != null)
                {
                    Session["CurrentUserId"] = accountDetails.Id;
                    FormsAuthentication.SetAuthCookie(accountDetails.Name, false);
                    var authTicket = new FormsAuthenticationTicket(1, accountDetails.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, accountDetails.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("DisplayFlightDetails", "Flight");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View();
        }
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            int id = Convert.ToInt32(Session["CurrentUserId"]);
            Account account = accountBLayer.GetUser(id);
            return View(account);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Account account)
        {
            if (ModelState.IsValid)
            {
                accountBLayer.UpdateProfile(account);
                return RedirectToAction("DisplayFlightDetails", "Flight");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View(account);

        }
        public ActionResult ViewProfile()
        {
            int id = Convert.ToInt32(Session["CurrentUserId"]);
            Account account = accountBLayer.GetUser(id);
            return View(account);
        }
    }
}