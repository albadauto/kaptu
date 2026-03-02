using Kaptu.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) { }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PremiumUsers> PremiumUsers { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Otp> Otp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
               .HasOne(p => p.User)
               .WithOne(p => p.Tenant)
               .HasForeignKey<Tenant>(p => p.UserId);

            modelBuilder.Entity<PremiumUsers>()
               .HasOne(p => p.User)
               .WithOne(p => p.PremiumUsers)
               .HasForeignKey<PremiumUsers>(p => p.UserId);

            modelBuilder.Entity<PremiumUsers>()
              .HasOne(p => p.Plans)
              .WithMany(p => p.PremiumUsers)
              .HasForeignKey(p => p.PlanId);

            modelBuilder.Entity<PurchaseHistory>()
               .HasOne(p => p.User)
               .WithMany(p => p.PurchaseHistory)
               .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
               .HasOne(p => p.Plans)
               .WithMany(p => p.User)
               .HasForeignKey(p => p.PlanId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
