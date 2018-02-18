using System;
using System.Threading.Tasks;
using System.Web.Http;
using AgioGlobal.Server.DistributedServices.Mappers;
using AgioGlobal.Server.DistributedServices.Messages.Flights;
using AgioGlobal.Server.DistributedServices.WebApi.Base;
using AgioGlobal.Server.Domain.Interfaces.Flights;
using AgioGlobal.Server.Domain.IoC.Containers;
using AgioGlobal.Server.Infrastructure.Helpers;
using Ninject;
using SharedLanguage = AgioGlobal.Server.Infrastructure.Resources.Language;

namespace AgioGlobal.Server.DistributedServices.WebApi.Flights.Controllers
{
    [RoutePrefix("api/Flight")]
    public class FlightController : BaseApiController
    {
        #region Fields

        /// <summary>
        /// AddressSearch service.
        /// </summary>
        private IFlightService FlightServices { get; set; }

        #endregion

        #region Constructor

        public FlightController(DistributedServicesAutoMapper distributedServicesAutoMapper, DomainIoCContainer domainIoCContainer)
            : base(distributedServicesAutoMapper, domainIoCContainer)
        {
            this.InitializeServices();
        }

        private void InitializeServices()
        {
            this.FlightServices = this.DomainIoCContainer.Resolver.Get<IFlightService>();
        }

        #endregion

        #region Actions

        // POST api/Flight/Create
        [Route("Create")]
        public async Task<IHttpActionResult> CreateFlight(FlightDTO model)
        {
            var resultMessage = string.Empty;

            try
            {
                //TraceManager.StartMethodTrace(Traces.IndexStackFrameAsynController, "model: " + JsonConvert.SerializeObject(model));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var request = DistributedServicesAutoMapper.Map<Domain.BO.Flights.FlightDTO>(model);

                FlightServices.CreateFlight(request);

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