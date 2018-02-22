using System.Collections.Generic;
using AgioGlobal.Server.Domain.BO.Airport;
using AgioGlobal.Server.Domain.Interfaces.Base;

namespace AgioGlobal.Server.Domain.Interfaces.Airport
{
    public interface IAirportService : IBaseService
    {
        void CreateAirport(AirportDTO request);
        AirportDTO GetAirport(AirportDTO airportDTO);
        List<AirportDTO> GetAirportList();
        void DeleteAirport(AirportDTO airportDTO);
        void UpdateAirport(AirportDTO request);
    }
}
