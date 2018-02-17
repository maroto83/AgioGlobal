using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Data.Interfaces.Flights;
using AgioGlobal.Server.Data.Interfaces.Mappers;
using AgioGlobal.Server.Data.Repositories.Base;
using AgioGlobal.Server.Data.Repositories.Flights.PredicateBuilders;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AgioGlobal.Server.Data.Repositories.Flights.Repositories
{
    public class FlightsRepository : BaseRepository, IFlightsRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataAutoMapper">Interface for injecting in base</param>
        public FlightsRepository(IDataAutoMapper dataAutoMapper)
            : base(dataAutoMapper)
        {

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get the flight list 
        /// </summary>
        /// <param name="flightEntity">Flight data</param>
        /// <returns>Return the flights List with the data </returns>
        public List<Flight> GetFlights(Flight flightEntity)
        {
            var flightsEntityList = new List<Flight>();

            try
            {
                //TraceManager.StartMethodTrace(parameters: "flightEntity: " + JsonConvert.SerializeObject(flightEntity));

                // Build the filters
                var getPredicateBuilderForGetFlights = FlightsPredicateBuilder.GetPredicateBuilderForGetFlights(flightEntity);

                var flights = this.DatabaseContext.Flight                               
                                .Where(getPredicateBuilderForGetFlights);

                if (flights.Any())
                {
                    flightsEntityList = DataAutoMapper.Map<List<Flight>>(flights.ToList());
                }

                return flightsEntityList;
            }
            finally
            {
                //TraceManager.FinishMethodTrace(output: "flightsEntityList: " + JsonConvert.SerializeObject(flightsEntityList));
            }
        }

        /// <summary>
        /// Update or insert in a flight
        /// </summary>
        /// <param name="flightEntity">entity with the info</param>
        public void UpSertFlight(Flight flightEntity)
        {
            try
            {
                //TraceManager.StartMethodTrace(parameters: "flightEntity: " + JsonConvert.SerializeObject(flightEntity));

                var flight = DataAutoMapper.Map<Models.Schemas.dbo.Flight>(flightEntity);
                //TraceManager.ObjectDataTrace("flight", JsonConvert.SerializeObject(flight));                              

                DatabaseContext.Flight.AddOrUpdate(flight);
                DatabaseContext.SaveChanges();
            }
            finally
            {
                //TraceManager.FinishMethodTrace();
            }
        }
        
        /// <summary>
        /// Delete a flight
        /// </summary>
        /// <param name="flightEntity">entity with the info</param>
        public void DeleteFlight(Flight flightEntity)
        {
            try
            {
                //TraceManager.StartMethodTrace(parameters: "flightEntity: " + JsonConvert.SerializeObject(flightEntity));

                var flightToDelete = DatabaseContext.Flight
                                        .FirstOrDefault(flight => flight.FlightId.Equals(flightEntity.FlightId)
                                                        || flight.Name.Equals(flightEntity.Name));

                if (flightToDelete != null)
                {
                    DatabaseContext.Flight.Remove(flightToDelete);
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
