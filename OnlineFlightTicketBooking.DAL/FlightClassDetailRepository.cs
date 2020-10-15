using OnlineFlightTicketBooking.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace OnlineFlightTicketBooking.DAL
{
    public interface IFlightClassDetailRepository
    {
        void AddFlightClassDetail(FlightClassDetail flightClassDetail);
        IEnumerable<FlightClassDetail> FlightClassDetails();
        FlightClassDetail GetFlightClassDetail(int flightClassDetailId);
        void UpdateFlightClassDetail(FlightClassDetail flightClassDetail);
        void DeleteFlightClassDetail(int id);
    }
    public class FlightClassDetailRepository:IFlightClassDetailRepository
    {

        public void AddFlightClassDetail(FlightClassDetail flightClassDetail)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.FlightClassDetails.Add(flightClassDetail);
                FlightDBContext.SaveChanges();
            }
        }
        public IEnumerable<FlightClassDetail> FlightClassDetails()
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.FlightClassDetails.Include("Flight").Include("FlightClass").ToList();
            }
        }
        public FlightClassDetail GetFlightClassDetail(int flightClassDetailId)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.FlightClassDetails.Where(flight => flight.FlightClassDetailId == flightClassDetailId).FirstOrDefault();
            }
        }
        public void UpdateFlightClassDetail(FlightClassDetail flightClassDetail)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.Entry(flightClassDetail).State = EntityState.Modified;
                FlightDBContext.SaveChanges();
            }
        }
        public void DeleteFlightClassDetail(int id)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                //Flight flight = GetFlight(id);
                FlightClassDetail flightClassDetail = FlightDBContext.FlightClassDetails.Find(id);
                FlightDBContext.FlightClassDetails.Remove(flightClassDetail);
                // FlightDBContext.Entry(flight).State = EntityState.Deleted;
                FlightDBContext.SaveChanges();
            }
        }
    }
}
