using System.Collections.Generic;
using AgioGlobal.Server.Domain.BO.Flights;
using AgioGlobal.Server.Domain.Interfaces.Base;

namespace AgioGlobal.Server.Domain.Interfaces.Flights
{
    public interface IFlightService : IBaseService
    {
        void CreateFlight(FlightDTO request);
        FlightDTO GetFlight(FlightDTO flightDTO);
        List<FlightDTO> GetFlightList();
        void DeleteFlight(FlightDTO flightDTO);
        void UpdateFlight(FlightDTO request);
    }
}
