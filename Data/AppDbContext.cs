using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wasla.Models;

namespace Wasla.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<AvailableRegion> AvailableRegions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Government>().HasMany(g => g.Regions).WithOne().HasForeignKey(r => r.GovernmentId);
            builder.Entity<Region>().HasMany(r => r.AvailableRegions).WithOne().HasForeignKey(ar => ar.RegionId);
        }
    }
}