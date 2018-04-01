using Microsoft.EntityFrameworkCore;
using Models;

namespace Lab1.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<GameLaunchParameters> GameLaunchParameters { get; set; }
        public DbSet<CurrencyPurchaseParameters> CurrencyPurchaseParameters { get; set; }
        public DbSet<FirstLaunchParameters> FirstLaunchParameters { get; set; }
        public DbSet<InGamePurchaseParameters> InGamePurchaseParameters { get; set; }
        public DbSet<StageStartParameters> StageStartParameters { get; set; }
        public DbSet<StageEndParameters> StageEndParameters { get; set; }
        public DbSet<DAU> DAU { get; set; }
        public DbSet<UniqueUsers> UniqueUsers { get; set; }
        public DbSet<Revenue> Revenue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=oidt;Username=postgres;Password=123");
        }
    }
}