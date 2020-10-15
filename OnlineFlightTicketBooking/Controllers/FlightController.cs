using AutoMapper;
using ExceptionFilterInMVC.Models;
using OnlineFlightTicketBooking.BL;
using OnlineFlightTicketBooking.Entity;
using OnlineFlightTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineFlightTicketBooking.Controllers
{
    [Authorize(Roles ="admin")]
    [LogCustomExceptionFilter]
    public class FlightController : Controller
    {
        IFlightBL flightBLayer;
        public FlightController()
        {
            flightBLayer = new FlightBL();
        }

        // GET: Flight
        public ActionResult AddFlight()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlight(FlightViewModel flightViewModel)
        {
            if(ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightViewModel, Flight>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var flight = mapper.Map<FlightViewModel, Flight>(flightViewModel);
                int flightId=flightBLayer.AddFlight(flight);
                TempData["FlightId"] = flightId;
               return  RedirectToAction("AddFlightClassDetail", "FlightClassDetail");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteFlight(int id)
        {
            Flight flight = flightBLayer.GetFlight(id);
            return View(flight);   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlight(Flight flight)
        {
            flightBLayer.DeleteFlight(flight.FlightId);
            return RedirectToAction("DisplayFlightDetails");
        }


        [HttpGet]
        public ActionResult DisplayFlightDetails(string search)
        {
            IEnumerable<Flight> flight = flightBLayer.Search(search);
            return View(flight);
        }

        [HttpGet]
        
        public ActionResult EditFlightDetails(int id)
        {
            Flight flight = flightBLayer.GetFlight(id);
            return View(flight);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFlightDetails(FlightViewModel flightViewModel)
        {
            Flight flight = null;
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightViewModel, Flight>(); });
                IMapper mapper = mapAccount.CreateMapper();
                flight = mapper.Map<FlightViewModel, Flight>(flightViewModel);
                flightBLayer.UpdateFlightDetails(flight);
                return RedirectToAction("DisplayFlightDetails");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View(flight);

        }
    }
}