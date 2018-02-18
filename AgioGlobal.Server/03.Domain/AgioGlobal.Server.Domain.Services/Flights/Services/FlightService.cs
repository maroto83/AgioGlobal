using System.Linq;
using AgioGlobal.Server.Data.Entities;
using AgioGlobal.Server.Data.Interfaces.Flights;
using AgioGlobal.Server.Data.IoC.Containers;
using AgioGlobal.Server.Domain.BO.Flights;
using AgioGlobal.Server.Domain.Interfaces.Flights;
using AgioGlobal.Server.Domain.Interfaces.Mappers;
using AgioGlobal.Server.Domain.Services.Base;
using Ninject;

namespace AgioGlobal.Server.Domain.Services.Flights.Services
{
    public class FlightService : BaseService, IFlightService
    {
        #region Fields

        /// <summary>
        /// Flight Repository
        /// </summary>
        private IFlightsRepository FlightRepository { get; set; }

        #endregion

        #region Costructor

        /// <summary>
        /// Constuctor
        /// </summary>
        public FlightService(IDomainAutoMapper domainAutoMapper, DataIoCContainer dataIoCContainer)
            : base(domainAutoMapper, dataIoCContainer)
        {
            InitializeRepositories();
        }

        /// <summary>
        /// Initialize the repositories
        /// </summary>
        private void InitializeRepositories()
        {
            FlightRepository = DataIoCContainer.Resolver.Get<IFlightsRepository>();
        }

        #endregion

        public void CreateFlight(FlightDTO request)
        {
            var flightEntity = DomainAutoMapper.Map<Flight>(request);
            FlightRepository.UpSertFlight(flightEntity);
        }

        public FlightDTO GetFlight(FlightDTO request)
        {
            var flightEntity = DomainAutoMapper.Map<Flight>(request);
            var flight = FlightRepository.GetFlights(flightEntity).FirstOrDefault();
            return DomainAutoMapper.Map<FlightDTO>(flight);
        }

        public void DeleteFlight(FlightDTO flightDTO)
        {
            var flightEntity = DomainAutoMapper.Map<Flight>(flightDTO);
            FlightRepository.DeleteFlight(flightEntity);
        }
    }
}
