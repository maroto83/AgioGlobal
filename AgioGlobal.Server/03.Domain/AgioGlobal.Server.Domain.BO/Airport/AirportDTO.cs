namespace AgioGlobal.Server.Domain.BO.Airport
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
        public string Name { get; set; }

        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public decimal Longitude { get; set; }
    }
}
