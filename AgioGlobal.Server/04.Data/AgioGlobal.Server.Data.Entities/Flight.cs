namespace AgioGlobal.Server.Data.Entities
{
    /// <summary>
    /// Flight entity
    /// </summary>
    public class Flight
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
        public Airport DepartureAirport { get; set; }

        /// <summary>
        /// The Destination airport
        /// </summary>
        public Airport DestinationAirport { get; set; }

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