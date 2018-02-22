using System.ComponentModel.DataAnnotations;

namespace AgioGlobal.Client.Presentation.Website.Airport.Models
{
    public class AirportModel
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
        [Required]
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate
        /// </summary>
        [Required]
        public decimal Longitude { get; set; }
    }
}