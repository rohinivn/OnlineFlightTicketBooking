using OnlineFlightTicketBooking.BL;
using System.Web.Mvc;

namespace OnlineFlightTicketBooking.Controllers
{
    public class TicketController : Controller
    {
        IFlightBL flightBLayer;
        public TicketController()
        {
            flightBLayer = new FlightBL();
        }
        // GET: Ticket
        public ActionResult BookTicket()
        {
            return View();
        }
    }
}