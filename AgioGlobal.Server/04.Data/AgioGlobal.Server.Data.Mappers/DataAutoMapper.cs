using AgioGlobal.Server.Data.Interfaces.Mappers;
using AgioGlobal.Server.Data.Models.Schemas.dbo;
using AutoMapper;
using System;

namespace AgioGlobal.Server.Data.Mappers
{
    /// <summary>
    /// Class to map in the Data Layer
    /// </summary>
    public class DataAutoMapper : IDataAutoMapper
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
        public DataAutoMapper()
        {
            this.ConfigureMappings();
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
                    cfg.CreateMap<Airport, Entities.Airport>();
                    cfg.CreateMap<Entities.Airport, Airport>();

                    cfg.CreateMap<Flight, Entities.Flight>();
                    cfg.CreateMap<Entities.Flight, Flight>();                   
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
