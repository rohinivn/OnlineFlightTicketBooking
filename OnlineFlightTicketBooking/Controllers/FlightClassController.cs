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
    public class FlightClassController : Controller
    {
        IFlightClassBL flightClassBL ;
        public FlightClassController()
        {
            flightClassBL = new FlightClassBL();
        }
        // GET: FlightClass
        public ActionResult AddFlightClass()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlightClass(FlightClassViewModel flightClassViewModel)
        {
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClassViewModel, FlightClass>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var flightClass = mapper.Map<FlightClassViewModel, FlightClass>(flightClassViewModel);
                flightClassBL.AddFlightClass(flightClass);
                return RedirectToAction("DisplayFlightClass");
            }
            return View();
        }
        [HttpGet]
        
        public ActionResult DeleteFlightClass(int id)
        {
            FlightClass flightClass = flightClassBL.GetFlightClass(id);
            return View(flightClass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlightClass(FlightClass flightClass)
        {
            flightClassBL.DeleteFlightClass(flightClass.FlightClassId);
            return RedirectToAction("DisplayFlightClass");
        }

        [HttpGet]
        public ActionResult EditFlightClass(int id)
        {
            FlightClass flightClass = flightClassBL.GetFlightClass(id);
            var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClass, FlightClassViewModel>(); });
            IMapper mapper = mapAccount.CreateMapper();
            FlightClassViewModel flightClassViewModel = mapper.Map<FlightClass, FlightClassViewModel>(flightClass);
            return View(flightClassViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFlightClass(FlightClassViewModel flightClassViewModel)
        {
            FlightClass flightClass = null;
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClassViewModel, FlightClass>(); });
                IMapper mapper = mapAccount.CreateMapper();
                flightClass = mapper.Map<FlightClassViewModel, FlightClass>(flightClassViewModel);
                flightClassBL.UpdateFlightClass(flightClass);
                return RedirectToAction("DisplayFlightClass");
            }
            return View(flightClass);

        }
        [HttpGet]
        public ActionResult DisplayFlightClass()
        {
            IEnumerable<FlightClass> flightClass = flightClassBL.GetAllFlights();
             return View(flightClass);
        }
    }
}