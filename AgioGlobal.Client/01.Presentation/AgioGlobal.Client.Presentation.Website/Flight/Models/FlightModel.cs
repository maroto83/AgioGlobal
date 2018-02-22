using System.ComponentModel.DataAnnotations;
using AgioGlobal.Client.Presentation.Website.Airport.Models;

namespace AgioGlobal.Client.Presentation.Website.Flight.Models
{
    public class FlightModel
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
        public AirportModel DepartureAirport { get; set; }

        /// <summary>
        /// The Destination airport
        /// </summary>
        public AirportModel DestinationAirport { get; set; }
    }
}