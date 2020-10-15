using OnlineFlightTicketBooking.DAL;
using OnlineFlightTicketBooking.Entity;
using System.Collections.Generic;

namespace OnlineFlightTicketBooking.BL
{
    public interface IFlightClassBL
    {
        List<FlightClass> GetFlightClasses();
        void AddFlightClass(FlightClass flightClass);
        IEnumerable<FlightClass> GetAllFlights();
        FlightClass GetFlightClass(int flightClassId);
        void UpdateFlightClass(FlightClass flightClass);
        void DeleteFlightClass(int id);
    }
    public class FlightClassBL:IFlightClassBL
    {
        IFlightClassRepository flightClassRepository =new FlightClassRepository();
        public List<FlightClass> GetFlightClasses()
        {
            return flightClassRepository.GetFlightClasses();
        }
        public void AddFlightClass(FlightClass flightClass)
        {
            flightClassRepository.AddFlightClass(flightClass);
        }
        public IEnumerable<FlightClass> GetAllFlights()
        {
            return flightClassRepository.GetFlightClass();
        }
        public FlightClass GetFlightClass(int flightClassId)
        {
            return flightClassRepository.GetFlightClass(flightClassId);
        }
        public void UpdateFlightClass(FlightClass flightClass)
        {
            flightClassRepository.UpdateFlightClass(flightClass);
        }
        public void DeleteFlightClass(int id)
        {
            flightClassRepository.DeleteFlightClass(id);
        }
      
    }
}
