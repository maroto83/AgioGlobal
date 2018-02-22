using System;
using System.Collections.Generic;
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

        public AirportController(): base()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            AirportServices = DomainIoCContainer.Resolver.Get<IAirportService>();
        }

        #endregion

        #region Actions

        #region POST api/Airport/Create
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

        #region POST api/Airport/GetAirportsList

        [Route("GetAirportsList")]
        public IHttpActionResult GetAirportsList()
        {
            List<AirportDTO> airportsListResponse = null;
            try
            {
                //TraceManager.StartMethodTrace();

                // get airports list
                var airportsList = AirportServices.GetAirportList();

                airportsListResponse = DistributedServicesAutoMapper.Map<List<AirportDTO>>(airportsList);

                //return airports list
                return Ok(airportsListResponse);

            }
            catch (Exception ex)
            {
                //if there was a other error then log and returns it to client side
                //TraceManager.ExceptionErrorTrace(ex);
                return ResponseMessage(HttpHelper.GetHttpResponseErrorMessage(ex.Message));
            }
            finally
            {
                //TraceManager.FinishMethodTrace(output: "response: " + JsonConvert.SerializeObject(response));
            }
        }

        #endregion

        #region POST api/Airport/Update
        [Route("Update")]
        public async Task<IHttpActionResult> UpdateAirport(AirportDTO model)
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

                AirportServices.UpdateAirport(request);

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

        #region POST api/Airport/Delete
        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteAirport(AirportDTO model)
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

                AirportServices.DeleteAirport(request);

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

        #endregion
    }

}