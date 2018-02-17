using AgioGlobal.Server.Data.Models.Schemas.dbo;
using AgioGlobal.Server.Data.Repositories.Helpers;
using System;
using System.Linq.Expressions;

namespace AgioGlobal.Server.Data.Repositories.Flights.PredicateBuilders
{
    public class FlightsPredicateBuilder
    {
        #region Public methods

        public static Expression<Func<Flight, bool>> GetPredicateBuilderForGetFlights(Entities.Flight flightEntity)
        {
            var predicate = PredicateBuilder.True<Flight>();

            if (flightEntity != null)
            {
                //Filter by FlightId
                if (flightEntity.FlightId > 0)
                {
                    predicate = predicate.And(where => where.FlightId.Equals(flightEntity.FlightId));
                }

                //Filter by Name
                if (!string.IsNullOrWhiteSpace(flightEntity.Name))
                {
                    predicate = predicate.And(where => where.Name.Equals(flightEntity.Name));
                }                
            }

            return predicate;
        }

        #endregion
    }
}
