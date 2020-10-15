using OnlineFlightTicketBooking.DAL;
using OnlineFlightTicketBooking.Entity;
using System.Collections.Generic;

namespace OnlineFlightTicketBooking.BL
{
    public interface IFlightBL
    {
        int AddFlight(Flight flight);
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlight(int flightId);
        void UpdateFlightDetails(Flight flight);
        void DeleteFlight(int id);
        IEnumerable<Flight> Search(string search);
    }
    public class FlightBL : IFlightBL
    {
        IFlightRepository flightRepository = new FlightRepository();
        public int AddFlight(Flight flight)
        {
            int id=flightRepository.AddFlight(flight);
            return id;
        }
        public IEnumerable<Flight> GetAllFlights()
        {
            return flightRepository.FlightDetails();
        }
        public IEnumerable<Flight> Search(string search)
        {
            return flightRepository.Search(search);
        }
        public Flight GetFlight(int flightId)
        {
            return flightRepository.GetFlight(flightId);
        }
        public void UpdateFlightDetails(Flight flight)
        {
            flightRepository.UpdateFlightDetails(flight);
        }
        public void DeleteFlight(int id)
        {
            flightRepository.DeleteFlightDetails(id);
        }
        //public IEnumerable<Flight> Search(string option, string search)
        //{
        //    return flightRepository.Search(option, search);
        //}
    }
}
