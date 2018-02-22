using System.Data.Entity.Migrations;
using System.Linq;
using AgioGlobal.Server.Data.Models.Schemas.dbo;
using AgioGlobal.Server.Infrastructure.Constants;

namespace AgioGlobal.Server.Data.DAL.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            if (!context.Airport.Any(airport => airport.Name.Equals(Constants.TestAirportName1)))
            {
                context.Airport.AddOrUpdate(new Airport{ Name = Constants.TestAirportName1 , Longitude = Constants.TestAirportLongitude1, Latitude = Constants.TestAirportLatitude1 });
            }

            if (!context.Airport.Any(airport => airport.Name.Equals(Constants.TestAirportName2)))
            {
                context.Airport.AddOrUpdate(new Airport { Name = Constants.TestAirportName2, Longitude = Constants.TestAirportLongitude2, Latitude = Constants.TestAirportLatitude2 });
            }

            if (!context.Airport.Any(airport => airport.Name.Equals(Constants.TestAirportName3)))
            {
                context.Airport.AddOrUpdate(new Airport { Name = Constants.TestAirportName3, Longitude = Constants.TestAirportLongitude3, Latitude = Constants.TestAirportLatitude3 });
            }

            if (!context.Airport.Any(airport => airport.Name.Equals(Constants.TestAirportName4)))
            {
                context.Airport.AddOrUpdate(new Airport { Name = Constants.TestAirportName4, Longitude = Constants.TestAirportLongitude4, Latitude = Constants.TestAirportLatitude4 });
            }
        }
    }
}
