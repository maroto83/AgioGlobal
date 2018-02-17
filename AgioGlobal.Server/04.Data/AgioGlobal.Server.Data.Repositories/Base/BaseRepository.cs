using AgioGlobal.Server.Data.DAL;
using AgioGlobal.Server.Data.DAL.Context;
using AgioGlobal.Server.Data.Interfaces.Base;
using AgioGlobal.Server.Data.Interfaces.Mappers;
using System;
using System.Data.Entity;

namespace AgioGlobal.Server.Data.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        #region Fields

        /// <summary>
        /// Objects maps container.
        /// </summary>
        public IDataAutoMapper DataAutoMapper { get; set; }

        /// <summary>
        /// Context of the database
        /// </summary>
        public DatabaseContext DatabaseContext { get; set; }

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="dataAutoMapper">Objects maps container</param>
        public BaseRepository(IDataAutoMapper dataAutoMapper)
        {
            DataAutoMapper = dataAutoMapper;
            DatabaseContext = new DatabaseContext();

            // To execute all pending migrations
            Database.SetInitializer(new DatabaseContextInitializer());
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
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
