using Microsoft.EntityFrameworkCore;
using ParkingManagerWebApp.Models.ParkingOperations;
using ParkingManagerWebApp.Models.PriceControl;

namespace ParkingManagerWebApp.Models
{
   public class ParkingManagerContext : DbContext
    {
        public ParkingManagerContext(DbContextOptions<ParkingManagerContext> options) : base(options)
        {
        }

        public DbSet<PriceControlModel> PriceControlList { get; set; }
        public DbSet<VehicleEntryModel> VehicleEntries { get; set; }
        public DbSet<VehicleExitModel> VehicleExits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PriceControlModel>().ToTable("PriceControl");
            builder.Entity<PriceControlModel>().HasKey(m => m.Id);

            builder.Entity<VehicleEntryModel>().ToTable("VehicleEntry");
            builder.Entity<VehicleEntryModel>().HasKey(m => m.Id);

            builder.Entity<VehicleExitModel>().ToTable("VehicleExit");
            builder.Entity<VehicleExitModel>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}