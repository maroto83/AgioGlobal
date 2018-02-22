using System.ComponentModel.DataAnnotations;

namespace AgioGlobal.Server.DistributedServices.Messages.Airport
{
    public class AirportDTO
    {
        /// <summary>
        /// Flighy id
        /// </summary>        
        public int AirportId { get; set; }

        /// <summary>
        /// Airport name
        /// </summary> 
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public float Longitude { get; set; }
    }
}
