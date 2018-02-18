using System;
using System.Threading.Tasks;
using System.Web.Http;
using AgioGlobal.Server.DistributedServices.Mappers;
using AgioGlobal.Server.DistributedServices.Messages.Airport;
using AgioGlobal.Server.DistributedServices.WebApi.Base;
using AgioGlobal.Server.Domain.Interfaces.Airport;
using AgioGlobal.Server.Domain.IoC.Containers;
using AgioGlobal.Server.Infrastructure.Helpers;
using Ninject;
using SharedLanguage = AgioGlobal.Server.Infrastructure.Resources.Language;

namespace AgioGlobal.Server.DistributedServices.WebApi.Airports.Controllers
{
    [RoutePrefix("api/Airport")]
    public class AirportController : BaseApiController
    {
        #region Fields

        /// <summary>
        /// AddressSearch service.
        /// </summary>
        private IAirportService AirportServices { get; set; }

        #endregion

        #region Constructor

        public AirportController(DistributedServicesAutoMapper distributedServicesAutoMapper, DomainIoCContainer domainIoCContainer)
            : base(distributedServicesAutoMapper, domainIoCContainer)
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            AirportServices = DomainIoCContainer.Resolver.Get<IAirportService>();
        }

        #endregion

        #region Actions

        // POST api/Airport/Create
        [Route("Create")]
        public async Task<IHttpActionResult> CreateAirport(AirportDTO model)
        {
            var resultMessage = string.Empty;

            try
            {
                //TraceManager.StartMethodTrace(Traces.IndexStackFrameAsynController, "model: " + JsonConvert.SerializeObject(model));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var request = DistributedServicesAutoMapper.Map<Domain.BO.Airport.AirportDTO>(model);

                AirportServices.CreateAirport(request);

                resultMessage = SharedLanguage.REQUEST_SUCCESSFUL;

                return Ok(resultMessage);
            }
            catch (Exception ex)
            {
                resultMessage = ""; //TraceManager.ExceptionErrorTrace(ex, Traces.IndexStackFrameAsynController);
                return ResponseMessage(HttpHelper.GetHttpResponseErrorMessage(resultMessage));
            }
            finally
            {
                //TraceManager.FinishMethodTrace(Traces.IndexStackFrameAsynController, "resultMessage: " + resultMessage);
            }
        }

        #endregion
    }

}