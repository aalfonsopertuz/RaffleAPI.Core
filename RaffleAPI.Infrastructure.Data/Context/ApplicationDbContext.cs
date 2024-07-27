using Microsoft.EntityFrameworkCore;
using RaffleAPI.Domain.Entities;

namespace RaffleAPI.Infrastructure.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<RaffleNumber> RaffleNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RaffleNumber>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
        }
    }
}
