using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Data.Interfaces.Base;
using System.Collections.Generic;

namespace AgioGlobal.Server.Data.Interfaces.Flights
{
    public interface IFlightsRepository : IBaseRepository
    {
        /// <summary>
        /// Get the flights list 
        /// </summary>
        /// <param name="flightEntity">Flight data</param>
        /// <returns>Return the flights List with the data </returns>
        List<Flight> GetFlights(Flight flightEntity);

        /// <summary>
        /// Get the full flights list 
        /// </summary>
        /// <returns>Return the full flights List with the data </returns>
        List<Flight> GetFlightList();

        /// <summary>
        /// Update or insert a flight
        /// </summary>
        /// <param name="flightEntity">entity with the info</param>
        void CreateFlight(Flight flightEntity);

        /// <summary>
        /// Delete a flight
        /// </summary>
        /// <param name="flightEntity">entity with the info</param>
        void DeleteFlight(Flight flightEntity);
        void UpdateFlight(Flight flightEntity);
    }
}
