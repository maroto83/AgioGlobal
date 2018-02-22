using AgioGlobal.Server.Domain.Interfaces.Airport;
using AgioGlobal.Server.Domain.Interfaces.Flights;
using AgioGlobal.Server.Domain.Interfaces.Mappers;
using AgioGlobal.Server.Domain.Mappers;
using AgioGlobal.Server.Domain.Services.Airport.Services;
using AgioGlobal.Server.Domain.Services.Flights.Services;
using Ninject;

namespace AgioGlobal.Server.Domain.IoC.Containers
{
    /// <summary>
    /// IocContainer class. Manage inversion of control system.
    /// </summary>
    public class DomainIoCContainer
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
        public DomainIoCContainer()
        {
            // Services.
            Resolver.Bind<IFlightService>().To<FlightService>();
            Resolver.Bind<IAirportService>().To<AirportService>();

            //// Mappers.
            Resolver.Bind<IDomainAutoMapper>().To<DomainAutoMapper>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets inversion of control resolver instance.
        /// </summary>
        public IKernel Resolver
        {
            get { return resolver ?? (resolver = new StandardKernel()); }
        }

        #endregion
    }
}
