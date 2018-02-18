using System.Linq;
using AgioGlobal.Server.Data.Interfaces.Airports;
using AgioGlobal.Server.Data.IoC.Containers;
using AgioGlobal.Server.Domain.BO.Airport;
using AgioGlobal.Server.Domain.Interfaces.Airport;
using AgioGlobal.Server.Domain.Interfaces.Mappers;
using AgioGlobal.Server.Domain.Services.Base;
using Ninject;

namespace AgioGlobal.Server.Domain.Services.Airport.Services
{
    public class AirportService : BaseService, IAirportService
    {
        #region Fields

        /// <summary>
        /// Airport Repository
        /// </summary>
        private IAirportsRepository AirportRepository { get; set; }

        #endregion

        #region Costructor

        /// <summary>
        /// Constuctor
        /// </summary>
        public AirportService(IDomainAutoMapper domainAutoMapper, DataIoCContainer dataIoCContainer)
            : base(domainAutoMapper, dataIoCContainer)
        {
            InitializeRepositories();
        }

        /// <summary>
        /// Initialize the repositories
        /// </summary>
        private void InitializeRepositories()
        {
            AirportRepository = DataIoCContainer.Resolver.Get<IAirportsRepository>();
        }

        #endregion

        public void CreateAirport(AirportDTO request)
        {
            var airportEntity = DomainAutoMapper.Map<Data.Entities.Airport>(request);
            AirportRepository.UpSertAirport(airportEntity);
        }

        public AirportDTO GetAirport(AirportDTO request)
        {
            var airportEntity = DomainAutoMapper.Map<Data.Entities.Airport>(request);
            var airport = AirportRepository.GetAirports(airportEntity).FirstOrDefault();
            return DomainAutoMapper.Map<AirportDTO>(airport);
        }

        public void DeleteAirport(AirportDTO airportDTO)
        {
            var airportEntity = DomainAutoMapper.Map<Data.Entities.Airport>(airportDTO);
            AirportRepository.DeleteAirport(airportEntity);
        }
    }
}
