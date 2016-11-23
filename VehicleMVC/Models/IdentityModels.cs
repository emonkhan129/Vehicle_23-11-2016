using Microsoft.AspNet.Identity.EntityFramework;

namespace VehicleMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("VehicleMVC")
        {
        }

        public System.Data.Entity.DbSet<VehicleMVC.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<VehicleMVC.Models.ScheduleVehicle> ScheduleVehicles { get; set; }

        public System.Data.Entity.DbSet<VehicleMVC.Models.Shift> Shifts { get; set; }
    }
}