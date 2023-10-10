using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Membership>Membership { get; set; }
        public DbSet<Role>Role { get; set; }
        public DbSet<SMSUser> SMSUser { get; set; }
    }
}
