using Microsoft.EntityFrameworkCore;
using ParkingManagerWebApp.Models.Parking;
using ParkingManagerWebApp.Models.PriceControl;

namespace ParkingManagerWebApp.Models
{
    public class ParkingManagerContext : DbContext
    {
        public ParkingManagerContext(DbContextOptions<ParkingManagerContext> options) : base(options)
        {
        }

        public DbSet<PriceControlModel> PriceControlList { get; set; }
        public DbSet<ParkingStayModel> ParkingStayList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PriceControlModel>().ToTable("TBPriceControl");
            builder.Entity<PriceControlModel>().HasKey(m => m.Id);

            builder.Entity<ParkingStayModel>().ToTable("TBParkingStay");
            builder.Entity<ParkingStayModel>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}