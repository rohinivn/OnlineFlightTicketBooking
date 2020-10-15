using AutoMapper;
using ExceptionFilterInMVC.Models;
using OnlineFlightTicketBooking.BL;
using OnlineFlightTicketBooking.Entity;
using OnlineFlightTicketBooking.Models;
using System.Collections.Generic;

using System.Web.Mvc;

namespace OnlineFlightTicketBooking.Controllers
{
    [Authorize(Roles = "admin")]
    [LogCustomExceptionFilter]
    public class FlightClassDetailController : Controller
    {
        IFlightClassDetailBL flightClassDetailBL;
        IFlightClassBL flightClassBL;
        public FlightClassDetailController()
        {
            flightClassDetailBL = new FlightClassDetailBL();
            flightClassBL = new FlightClassBL();
        }
        // GET: FlightClassDetail
        public ActionResult AddFlightClassDetail()
        {
            List<FlightClass> flightClass = flightClassBL.GetFlightClasses();
            ViewBag.flightClass = new SelectList(flightClass, "FlightClassId", "FlightClassName");
            FlightClassDetailViewModel flightClassDetail = new FlightClassDetailViewModel();
            flightClassDetail.FlightId = (int)TempData["FlightId"];
            return View(flightClassDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlightClassDetail(FlightClassDetailViewModel flightClassDetailView)
        {
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClassDetailViewModel, FlightClassDetail>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var flightClassDetail = mapper.Map<FlightClassDetailViewModel, FlightClassDetail>(flightClassDetailView);
                flightClassDetailBL.AddFlightClassDetail(flightClassDetail);
                return RedirectToAction("DisplayFlightClassDetail");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteFlightClassDetail(int id)
        {
            FlightClassDetail flightClassDetails = flightClassDetailBL.GetFlightClassDetail(id);
            return View(flightClassDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlightClassDetail(FlightClassDetail flightClassDetail)
        {
            flightClassDetailBL.DeleteFlightClassDetail(flightClassDetail.FlightClassDetailId);
            return RedirectToAction("DisplayFlightClassDetail");
        }

        [HttpGet]
        public ActionResult EditFlightClassDetail(int id)
        {
            List<FlightClass> flightClass = flightClassBL.GetFlightClasses();
            ViewBag.flightClass = new SelectList(flightClass, "FlightClassId", "FlightClassName");
            FlightClassDetailViewModel flightClassDetailViewModel;
            FlightClassDetail flightClassDetails = flightClassDetailBL.GetFlightClassDetail(id);
            var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClassDetail, FlightClassDetailViewModel>(); });
            IMapper mapper = mapAccount.CreateMapper();
            flightClassDetailViewModel = mapper.Map<FlightClassDetail, FlightClassDetailViewModel>(flightClassDetails);
            return View(flightClassDetailViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFlightClassDetail(FlightClassDetailViewModel flightClassDetailViewModel)
        {
            FlightClassDetail flightClassDetail = null;
            if (ModelState.IsValid)
            {
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<FlightClassDetailViewModel, FlightClassDetail>(); });
                IMapper mapper = mapAccount.CreateMapper();
                flightClassDetail = mapper.Map<FlightClassDetailViewModel, FlightClassDetail>(flightClassDetailViewModel);
                flightClassDetailBL.UpdateFlightClassDetail(flightClassDetail);
                return RedirectToAction("DisplayFlightClassDetail");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Values");
            }
            return View(flightClassDetail);

        }
        [HttpGet]
        public ActionResult DisplayFlightClassDetail()
        {
            IEnumerable<FlightClassDetail> flightclassDetail = flightClassDetailBL.GetAllFlightClassDetail();
            return View(flightclassDetail);
        }
    }
}