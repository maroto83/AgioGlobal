using AgioGlobal.Server.Domain.BO.Airport;

namespace AgioGlobal.Server.Domain.BO.Flights
{
    public class FlightDTO
    {
        /// <summary>
        /// Flighy id
        /// </summary>        
        public int FlightId { get; set; }

        /// <summary>
        /// Flight name
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// The departure airport
        /// </summary>
        public AirportDTO DepartureAirport { get; set; }

        /// <summary>
        /// The Destination airport
        /// </summary>
        public AirportDTO DestinationAirport { get; set; }
    }
}
