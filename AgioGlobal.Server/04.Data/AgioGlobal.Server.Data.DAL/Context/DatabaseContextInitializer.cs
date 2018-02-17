using AgioGlobal.Server.Data.DAL.Migrations;
using System.Data.Entity;

namespace AgioGlobal.Server.Data.DAL.Context
{
    public class DatabaseContextInitializer : MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>
    {
        public DatabaseContextInitializer()
        {
        }
    }
}
