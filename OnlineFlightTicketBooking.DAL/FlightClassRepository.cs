using OnlineFlightTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightTicketBooking.DAL
{
    public interface IFlightClassRepository
    {
        void AddFlightClass(FlightClass flightClass);
        IEnumerable<FlightClass> GetFlightClass();
        FlightClass GetFlightClass(int flightClassId);
        void UpdateFlightClass(FlightClass flightClass);
        void DeleteFlightClass(int id);
        List<FlightClass> GetFlightClasses();
    }
    public class FlightClassRepository:IFlightClassRepository
    {
        public void AddFlightClass(FlightClass flightClass)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.FlightClass.Add(flightClass);
                FlightDBContext.SaveChanges();
            }
        }
        public IEnumerable<FlightClass> GetFlightClass()
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.FlightClass.ToList();
            }
        }
        public FlightClass GetFlightClass(int flightClassId)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.FlightClass.Where(flight => flight.FlightClassId == flightClassId).FirstOrDefault();
            }
        }
        public void UpdateFlightClass(FlightClass flightClass)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.Entry(flightClass).State = EntityState.Modified;
                FlightDBContext.SaveChanges();
            }
        }
        public void DeleteFlightClass(int id)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightClass flightClass = FlightDBContext.FlightClass.Find(id);
                FlightDBContext.FlightClass.Remove(flightClass);
                FlightDBContext.SaveChanges();
            }
        }
        public List<FlightClass> GetFlightClasses()
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                List<FlightClass> flightclass = FlightDBContext.FlightClass.ToList();
                //List<FlightClass> flightClasses = FlightDBContext.FlightClassDetails.SqlQuery("select * from FlightClass where ");               
                return flightclass;
            }
        }

    }
}
