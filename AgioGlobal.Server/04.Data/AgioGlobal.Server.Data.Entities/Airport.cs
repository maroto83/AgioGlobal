namespace AgioGlobal.Server.Data.Entities
{
    /// <summary>
    /// Airport entity
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Airport Id
        /// </summary>        
        public int AirportId { get; set; }

        /// <summary>
        /// Airport name
        /// </summary>        
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
