using OnlineFlightTicketBooking.DAL;
using OnlineFlightTicketBooking.Entity;
using System.Collections.Generic;


namespace OnlineFlightTicketBooking.BL
{
    public interface IFlightClassDetailBL
    {
        void AddFlightClassDetail(FlightClassDetail flightClassDetail);
        IEnumerable<FlightClassDetail> GetAllFlightClassDetail();
        FlightClassDetail GetFlightClassDetail(int flightClassDetailId);
        void UpdateFlightClassDetail(FlightClassDetail flightClassDetail);
        void DeleteFlightClassDetail(int id);
    }
    public class FlightClassDetailBL:IFlightClassDetailBL
    {
        IFlightClassDetailRepository flightClassDetailRepository = new FlightClassDetailRepository();
        
        public void AddFlightClassDetail(FlightClassDetail flightClassDetail)
        {
            flightClassDetailRepository.AddFlightClassDetail(flightClassDetail);
        }
        public IEnumerable<FlightClassDetail> GetAllFlightClassDetail()
        {
            return flightClassDetailRepository.FlightClassDetails();
        }
        public FlightClassDetail GetFlightClassDetail(int flightClassDetailId)
        {
            return flightClassDetailRepository.GetFlightClassDetail(flightClassDetailId);
        }
        public void UpdateFlightClassDetail(FlightClassDetail flightClassDetail)
        {
            flightClassDetailRepository.UpdateFlightClassDetail(flightClassDetail);
        }
        public void DeleteFlightClassDetail(int id)
        {
            flightClassDetailRepository.DeleteFlightClassDetail(id);
        }
    }
}
