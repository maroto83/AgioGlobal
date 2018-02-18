using System.ComponentModel.DataAnnotations;

namespace AgioGlobal.Server.Data.Models.Schemas.dbo
{
    /// <summary>
    /// Flight database table
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Flighy id
        /// </summary>
        [Key]
        public int FlightId { get; set; }

        /// <summary>
        /// Flight name
        /// </summary>
        [MaxLength(100),Required]
        public string Name { get; set; }

        /// <summary>
        /// Get the key of the register
        /// </summary>
        /// <returns>The key of the register</returns>
        public int GetKey()
        {
            return FlightId;
        }
    }
}
