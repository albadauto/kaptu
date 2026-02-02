using Kaptu.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) { }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<User> User { get; set; }
    }
}
