using Microsoft.EntityFrameworkCore;
using Vims_Webapi.Model;

namespace Vims_Webapi.Model
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Vehicle_info> vehicle_info { get; set; }
        public DbSet<policy> policy { get; set; }
        public DbSet<renew_policy> renew_policy { get; set; }
        public DbSet<payment_info> payment_info { get; set; }
        public DbSet<Claim> Claim { get; set; }
        public DbSet<AllPolicies> AllPolicies { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Admin> Admin { get; set; }


    }
}
