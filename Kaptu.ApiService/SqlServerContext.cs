using Kaptu.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) { }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Otp> Otp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasOne(p => p.User)
                .WithOne(p => p.Tenant)
                .HasForeignKey<Tenant>(p => p.UserId);
        }
    }
}
