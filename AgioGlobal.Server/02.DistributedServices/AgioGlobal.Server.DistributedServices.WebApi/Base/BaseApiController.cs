using AgioGlobal.Server.DistributedServices.Mappers;
using System.Web.Http;
using AgioGlobal.Server.Domain.IoC.Containers;

namespace AgioGlobal.Server.DistributedServices.WebApi.Base
{
    public class BaseApiController : ApiController
    {
        #region Properties

        /// <summary>
        /// Objects maps container.
        /// </summary>
        public DistributedServicesAutoMapper DistributedServicesAutoMapper { get; set; }

        public DomainIoCContainer DomainIoCContainer { get; set; }

        #endregion

        #region Constructor

        public BaseApiController(DistributedServicesAutoMapper distributedServicesAutoMapper, DomainIoCContainer domainIoCContainer)
        {
            DomainIoCContainer = domainIoCContainer;
            DistributedServicesAutoMapper = distributedServicesAutoMapper;
        }

        #endregion
    }

}