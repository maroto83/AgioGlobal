using AgioGlobal.Server.Data.DAL;
using AgioGlobal.Server.Data.IoC.Containers;
using AgioGlobal.Server.Domain.Interfaces.Base;
using System;
using AgioGlobal.Server.Domain.Interfaces.Mappers;

namespace AgioGlobal.Server.Domain.Services.Base
{
    public class BaseService : IBaseService 
    {
        #region Fields

        /// <summary>
        /// Objects maps container.
        /// </summary>
        public IDomainAutoMapper DomainAutoMapper { get; set; }

        /// <summary>
        /// Container of IoC for Data Layer
        /// </summary>
        public DataIoCContainer DataIoCContainer { get; set; }

        /// <summary>
        /// Context of the database
        /// </summary>
        public DatabaseContext DatabaseContext { get; set; }

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="domainAutoMapper">Objects maps container</param>
        /// <param name="dataIoCContainer">Container of IoC for Data Layer</param>
        public BaseService(IDomainAutoMapper domainAutoMapper, DataIoCContainer dataIoCContainer)
        {
            DomainAutoMapper = domainAutoMapper;
            DatabaseContext = new DatabaseContext();
            DataIoCContainer = dataIoCContainer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="domainAutoMapper">Objects maps container</param>
        public BaseService(IDomainAutoMapper domainAutoMapper)
        {
            DomainAutoMapper = domainAutoMapper;
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The bulk of the clean-up code is implemented in Dispose(bool)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        #endregion
    }
}
