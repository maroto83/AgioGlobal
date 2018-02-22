using AgioGlobal.Server.DistributedServices.Mappers;
using AgioGlobal.Server.Domain.Interfaces.Airport;
using AgioGlobal.Server.Domain.Interfaces.Flights;

namespace AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Managers
{
    public static class TestEnvironmentManager
    {
        public static void DeleteFlightTest(IFlightService flightService, string name)
        {
            flightService.DeleteFlight(new Domain.BO.Flights.FlightDTO { Name = name });
        }

        public static void DeleteAirportTest(IAirportService airportService, string name)
        {
            airportService.DeleteAirport(new Domain.BO.Airport.AirportDTO() { Name = name });
        }
    }
}
