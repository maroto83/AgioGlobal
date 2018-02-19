using System.ComponentModel.DataAnnotations;
using AgioGlobal.Server.DistributedServices.Messages.Airport;

namespace AgioGlobal.Server.DistributedServices.Messages.Flights
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
        [Required]
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
