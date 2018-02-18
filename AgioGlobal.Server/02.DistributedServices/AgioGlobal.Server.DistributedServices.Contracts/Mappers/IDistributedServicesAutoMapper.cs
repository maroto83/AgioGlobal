namespace AgioGlobal.Server.DistributedServices.Contracts.Mappers
{
    /// <summary>
    /// Class to map in the Domain Layer
    /// </summary>
    public interface IDistributedServicesAutoMapper
    {
        /// <summary>
        /// Convert de sourceObject to TDestination object
        /// </summary>
        /// <typeparam name="TDestination">Object finish</typeparam>
        /// <param name="sourceObject">Object to change</param>
        /// <returns>Object change to TDestination</returns>
        TDestination Map<TDestination>(object sourceObject);
    }
}
