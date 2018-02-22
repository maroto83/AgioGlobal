namespace AgioGlobal.Server.Data.Interfaces.Mappers
{
    /// <summary>
    /// Class to map in the Data Layer
    /// </summary>
    public interface IDataAutoMapper
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
