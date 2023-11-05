using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS1._0TransactionServices.Models;

namespace SMS1._0TransactionServices.DB_Context
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public  DbSet<RoleMapping>RoleMapping { get; set; }
        public DbSet<SMSMembershipMapping>SMSMembershipMapping{ get; set; }
    }
}
