using System;
using AgioGlobal.Server.DistributedServices.Contracts.Mappers;
using AgioGlobal.Server.DistributedServices.Messages.Airport;
using AgioGlobal.Server.DistributedServices.Messages.Flights;
using AutoMapper;

namespace AgioGlobal.Server.DistributedServices.Mappers
{
    /// <summary>
    /// Class to map in the Domain Layer
    /// </summary>
    public class DistributedServicesAutoMapper : IDistributedServicesAutoMapper
    {
        #region Fields

        /// <summary>
        /// Mapper container where mappings are registered-
        /// </summary>
        private MapperConfiguration config;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DistributedServicesAutoMapper()
        {
            ConfigureMappings();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initialize mapping configuration.
        /// </summary>
        private void ConfigureMappings()
        {
            try
            {
                config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FlightDTO, Domain.BO.Flights.FlightDTO>();
                    cfg.CreateMap<Domain.BO.Flights.FlightDTO, FlightDTO>();

                    cfg.CreateMap<AirportDTO, Domain.BO.Airport.AirportDTO>();
                    cfg.CreateMap<Domain.BO.Airport.AirportDTO, AirportDTO>();

                });
            }
            catch (Exception ex)
            {
                //TraceManager.ExceptionErrorTrace(ex);
                throw;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Convert de sourceObject to TDestination object
        /// </summary>
        /// <typeparam name="TDestination">Object finish</typeparam>
        /// <param name="sourceObject">Object to change</param>
        /// <returns>Object change to TDestination</returns>
        public TDestination Map<TDestination>(object sourceObject)
        {
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(sourceObject);
        }

        #endregion
    }
}
