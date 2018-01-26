using System.Data.Entity;

namespace EntityExample
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext() : base("dbconnection")
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}