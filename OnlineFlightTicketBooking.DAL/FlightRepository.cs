using OnlineFlightTicketBooking.Entity;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFlightTicketBooking.DAL
{
    public interface IFlightRepository
    {
        int AddFlight(Flight flight);
        IEnumerable<Flight> FlightDetails();
        Flight GetFlight(int flightId);
        void UpdateFlightDetails(Flight flight);
        void DeleteFlightDetails(int id);
        IEnumerable<Flight> Search(string search);
    }
    public class FlightRepository:IFlightRepository
    {
        public int AddFlight(Flight flight)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.Flights.Add(flight);
                FlightDBContext.SaveChanges();
                return flight.FlightId;
            }
        }
        public IEnumerable<Flight> FlightDetails()
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.Flights.ToList();
            }
        }
        public Flight GetFlight(int flightId)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                return FlightDBContext.Flights.Where(flight => flight.FlightId == flightId).FirstOrDefault();
            }
        }
        public void UpdateFlightDetails(Flight flight)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                FlightDBContext.Entry(flight).State = EntityState.Modified;
                FlightDBContext.SaveChanges();
            }
        }
        public void DeleteFlightDetails(int id)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                //Flight flight = GetFlight(id);
                Flight flight = FlightDBContext.Flights.Find(id);
                FlightDBContext.Flights.Remove(flight);
                // FlightDBContext.Entry(flight).State = EntityState.Deleted;
                FlightDBContext.SaveChanges();
            }
        }
        public IEnumerable<Flight> Search(string search)
        {
            using (OnlineFlightTicketBookingDBContext FlightDBContext = new OnlineFlightTicketBookingDBContext())
            {
                IEnumerable<Flight> flights = FlightDBContext.Flights.Where(flight => flight.FlightName.Contains(search)||flight.StartLocation.Contains(search)||flight.TargetLoation.Contains(search)||search==null).ToList();
                return flights;
            }
        }
    }
}
