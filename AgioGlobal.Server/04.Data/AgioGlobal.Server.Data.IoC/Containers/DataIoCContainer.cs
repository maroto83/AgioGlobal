using AgioGlobal.Server.Data.Interfaces.Airports;
using AgioGlobal.Server.Data.Interfaces.Flights;
using AgioGlobal.Server.Data.Interfaces.Mappers;
using AgioGlobal.Server.Data.Mappers;
using AgioGlobal.Server.Data.Repositories.Airports.Repositories;
using AgioGlobal.Server.Data.Repositories.Flights.Repositories;
using Ninject;

namespace AgioGlobal.Server.Data.IoC.Containers
{
    /// <summary>
    /// IocContainer class. Manage inversion of control system.
    /// </summary>
    public class DataIoCContainer
    {
        #region Fields

        /// <summary>
        /// Inversion of control resolver instance.
        /// </summary>
        private IKernel resolver;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DataIoCContainer()
        {
            // Repositories.
            this.Resolver.Bind<IFlightsRepository>().To<FlightsRepository>();
            this.Resolver.Bind<IAirportsRepository>().To<AirportsRepository>();            

            // Mappers.
            this.Resolver.Bind<IDataAutoMapper>().To<DataAutoMapper>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets inversion of control resolver instance.
        /// </summary>
        public IKernel Resolver
        {
            get { return this.resolver ?? (this.resolver = new StandardKernel()); }
        }

        #endregion
    }
}
