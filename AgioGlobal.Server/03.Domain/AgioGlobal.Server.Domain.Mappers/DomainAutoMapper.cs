using System;
using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Domain.BO.Airport;
using AgioGlobal.Server.Domain.BO.Flights;
using AgioGlobal.Server.Domain.Interfaces.Mappers;
using AutoMapper;

namespace AgioGlobal.Server.Domain.Mappers
{
    /// <summary>
    /// Class to map in the Domain Layer
    /// </summary>
    public class DomainAutoMapper : IDomainAutoMapper
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
        public DomainAutoMapper()
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
                    cfg.CreateMap<FlightDTO, Flight>();
                    cfg.CreateMap<Flight, FlightDTO>();

                    cfg.CreateMap<AirportDTO, Airport>();
                    cfg.CreateMap<Airport, AirportDTO>();
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
            try
            {
                var mapper = config.CreateMapper();
                return mapper.Map<TDestination>(sourceObject);
            }
            catch (Exception ex)
            {
                //TraceManager.ExceptionErrorTrace(ex);
                throw;
            }
        }

        #endregion
    }
}
