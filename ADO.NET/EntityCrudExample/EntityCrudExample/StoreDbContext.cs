using System.Data.Entity;

namespace EntityCrudExample
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("dbconnection")
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        
    }
}