using System.ComponentModel.DataAnnotations;

namespace AgioGlobal.Server.Data.Models.Schemas.dbo
{
    /// <summary>
    /// Airport database table
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Airport Id
        /// </summary>
        [Key]
        public int AirportId { get; set; }

        /// <summary>
        /// Airport name
        /// </summary>
        [MaxLength(100), Required]
        public string Name { get; set; }

        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Get the key of the register
        /// </summary>
        /// <returns>The key of the register</returns>
        public int GetKey()
        {
            return AirportId;
        }
    }
}
