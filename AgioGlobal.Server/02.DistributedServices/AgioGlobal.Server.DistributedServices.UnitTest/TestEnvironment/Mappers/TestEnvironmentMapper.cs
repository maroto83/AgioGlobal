using AgioGlobal.Server.Domain.BO.Airport;
using AgioGlobal.Server.Domain.BO.Flights;

namespace AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Mappers
{
    public static class TestEnvironmentMapper
    {
        public static FlightDTO BuildFlightDTOFromData(string testFlightNameForCreateFlight)
        {
            return new FlightDTO()
            {
                FlightId = 1,
                Name = testFlightNameForCreateFlight
            };
        }

        public static AirportDTO BuildAirportDTOFromData(string testAirportNameForCreateAirport)
        {
            return new AirportDTO
            {
                AirportId = 1,
                Name = testAirportNameForCreateAirport,
                Latitude = 0,
                Longitude = 0
            };
        }
    }
}
