using System.ComponentModel.DataAnnotations;

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
    }
}
