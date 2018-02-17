using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Data.Interfaces.Airports;
using AgioGlobal.Server.Data.Interfaces.Mappers;
using AgioGlobal.Server.Data.Repositories.Base;
using AgioGlobal.Server.Data.Repositories.Airports.PredicateBuilders;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AgioGlobal.Server.Data.Repositories.Airports.Repositories
{
    public class AirportsRepository : BaseRepository, IAirportsRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataAutoMapper">Interface for injecting in base</param>
        public AirportsRepository(IDataAutoMapper dataAutoMapper)
            : base(dataAutoMapper)
        {

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get the airport list 
        /// </summary>
        /// <param name="airportEntity">Airport data</param>
        /// <returns>Return the airports List with the data </returns>
        public List<Airport> GetAirports(Airport airportEntity)
        {
            var airportsEntityList = new List<Airport>();

            try
            {
                //TraceManager.StartMethodTrace(parameters: "airportEntity: " + JsonConvert.SerializeObject(airportEntity));

                // Build the filters
                var getPredicateBuilderForGetAirports = AirportsPredicateBuilder.GetPredicateBuilderForGetAirports(airportEntity);

                var airports = this.DatabaseContext.Airport
                                .Where(getPredicateBuilderForGetAirports);

                if (airports.Any())
                {
                    airportsEntityList = DataAutoMapper.Map<List<Airport>>(airports.ToList());
                }

                return airportsEntityList;
            }
            finally
            {
                //TraceManager.FinishMethodTrace(output: "airportsEntityList: " + JsonConvert.SerializeObject(airportsEntityList));
            }
        }

        /// <summary>
        /// Update or insert in a airport
        /// </summary>
        /// <param name="airportEntity">entity with the info</param>
        public void UpSertAirport(Airport airportEntity)
        {
            try
            {
                //TraceManager.StartMethodTrace(parameters: "airportEntity: " + JsonConvert.SerializeObject(airportEntity));

                var airport = DataAutoMapper.Map<Models.Schemas.dbo.Airport>(airportEntity);
                //TraceManager.ObjectDataTrace("airport", JsonConvert.SerializeObject(airport));                              

                DatabaseContext.Airport.AddOrUpdate(airport);
                DatabaseContext.SaveChanges();
            }
            finally
            {
                //TraceManager.FinishMethodTrace();
            }
        }

        /// <summary>
        /// Delete a airport
        /// </summary>
        /// <param name="airportEntity">entity with the info</param>
        public void DeleteAirport(Airport airportEntity)
        {
            try
            {
                //TraceManager.StartMethodTrace(parameters: "airportEntity: " + JsonConvert.SerializeObject(airportEntity));

                var airportToDelete = DatabaseContext.Airport
                                        .FirstOrDefault(airport => airport.AirportId.Equals(airportEntity.AirportId)
                                                        || airport.Name.Equals(airportEntity.Name));

                if (airportToDelete != null)
                {
                    DatabaseContext.Airport.Remove(airportToDelete);
                    DatabaseContext.SaveChanges();
                }

            }
            finally
            {
                //TraceManager.FinishMethodTrace();
            }
        }

        #endregion
    }
}
