using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Data.Interfaces.Base;
using System.Collections.Generic;

namespace AgioGlobal.Server.Data.Interfaces.Airports
{
    public interface IAirportsRepository : IBaseRepository
    {
        /// <summary>
        /// Get the airports list 
        /// </summary>
        /// <param name="airportEntity">Airport data</param>
        /// <returns>Return the airports List with the data </returns>
        List<Airport> GetAirports(Airport airportEntity);

        /// <summary>
        /// Update or insert a airport
        /// </summary>
        /// <param name="airportEntity">entity with the info</param>
        void UpSertAirport(Airport airportEntity);

        /// <summary>
        /// Delete a airport
        /// </summary>
        /// <param name="airportEntity">entity with the info</param>
        void DeleteAirport(Airport airportEntity);
    }
}
