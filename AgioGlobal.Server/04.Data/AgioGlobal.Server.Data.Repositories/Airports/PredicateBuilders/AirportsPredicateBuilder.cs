using AgioGlobal.Server.Data.Models.Schemas.dbo;
using AgioGlobal.Server.Data.Repositories.Helpers;
using System;
using System.Linq.Expressions;

namespace AgioGlobal.Server.Data.Repositories.Airports.PredicateBuilders
{
    public class AirportsPredicateBuilder
    {
        #region Public methods

        public static Expression<Func<Airport, bool>> GetPredicateBuilderForGetAirports(Entities.Airport airportEntity)
        {
            var predicate = PredicateBuilder.True<Airport>();

            if (airportEntity != null)
            {
                //Filter by AirportId
                if (airportEntity.AirportId > 0)
                {
                    predicate = predicate.And(where => where.AirportId.Equals(airportEntity.AirportId));
                }

                //Filter by Name
                if (!string.IsNullOrWhiteSpace(airportEntity.Name))
                {
                    predicate = predicate.And(where => where.Name.Equals(airportEntity.Name));
                }
            }

            return predicate;
        }

        #endregion
    }
}
