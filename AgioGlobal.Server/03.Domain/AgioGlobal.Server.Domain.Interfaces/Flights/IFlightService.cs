using AgioGlobal.Server.Domain.BO.Flights;
using AgioGlobal.Server.Domain.Interfaces.Base;

namespace AgioGlobal.Server.Domain.Interfaces.Flights
{
    public interface IFlightService : IBaseService
    {
        void CreateFlight(FlightDTO request);
        FlightDTO GetFlight(FlightDTO flightDTO);
        void DeleteFlight(FlightDTO flightDTO);
    }
}
