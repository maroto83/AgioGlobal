using AgioGlobal.Server.Data.Models.Schemas.dbo;
using System.Data.Entity;

namespace AgioGlobal.Server.Data.DAL
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DatabaseContext() : base("DatabaseContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        /// <summary>
        /// VehicleMakes database table.
        /// </summary>
        public DbSet<Airport> Airport { get; set; }

        /// <summary>
        /// VehicleModels database table.
        /// </summary>
        public DbSet<Flight> Flight { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}