using System.Net.Http;
using System.Web.Http;
using AgioGlobal.Server.DistributedServices.Mappers;
using AgioGlobal.Server.DistributedServices.WebApi.Airports.Controllers;
using AgioGlobal.Server.DistributedServices.WebApi.Flights.Controllers;
using AgioGlobal.Server.Domain.Interfaces.Airport;
using AgioGlobal.Server.Domain.Interfaces.Flights;
using AgioGlobal.Server.Domain.IoC.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace AgioGlobal.Server.DistributedServices.UnitTest.Base
{
    /// <summary>
    /// Descripción resumida de BaseUnitTest
    /// </summary>
    [TestClass]
    public class BaseUnitTest
    {
        #region Properties

        public DistributedServicesAutoMapper DistributedServicesAutoMapper = new DistributedServicesAutoMapper();
        public DomainIoCContainer DomainIoCContainer = new DomainIoCContainer();

        #endregion

        #region Controllers
        
        private FlightController flightController;
        public FlightController FlightController
        {
            get
            {
                return flightController ?? (flightController = new FlightController(DistributedServicesAutoMapper, DomainIoCContainer)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                });
            }
        }

        private AirportController airportController;
        public AirportController AirportController
        {
            get
            {
                return airportController ?? (airportController = new AirportController(DistributedServicesAutoMapper, DomainIoCContainer)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                });
            }
        }

        #endregion

        #region Services

        private IFlightService flightService;
        public IFlightService FlightService
        {
            get { return flightService ?? (flightService = DomainIoCContainer.Resolver.Get<IFlightService>()); }
        }

        private IAirportService airportService;
        public IAirportService AirportService
        {
            get { return airportService ?? (airportService = DomainIoCContainer.Resolver.Get<IAirportService>()); }
        }

        #endregion

        #region Constructor

        public BaseUnitTest()
        {
        
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion
    }

}
