using Microsoft.EntityFrameworkCore;
using Models.Events;
using Models.Parameters;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<CurrencyPurchaseParameter> CurrencyPurchaseParameters { get; set; }
        public DbSet<FirstLaunchParameter> FirstLaunchParameters { get; set; }
        public DbSet<InGamePurchaseParameter> InGamePurchaseParameters { get; set; }
        public DbSet<StageStartParameter> StageStartParameters { get; set; }
        public DbSet<StageEndParameter> StageEndParameters { get; set; }
        public DbSet<CurrencyPurchaseEvent> CurrencyPurchaseEvents { get; set; }
        public DbSet<FirstLaunchEvent> FirstLaunchEvents { get; set; }
        public DbSet<InGamePurchaseEvent> InGamePurchaseEvents { get; set; }
        public DbSet<StageEndEvent> StageEndEvents { get; set; }
        public DbSet<StageStartEvent> StageStartEvents { get; set; }
        public DbSet<GameLaunchEvent> GameLaunchEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyPurchaseParameter>().ToTable("CurrencyPurchase", "Parameters");
            modelBuilder.Entity<CurrencyPurchaseEvent>().ToTable("CurrencyPurchase", "Events");
            modelBuilder.Entity<StageStartParameter>().ToTable("StageStart", "Parameters");
            modelBuilder.Entity<StageStartEvent>().ToTable("StageStart", "Events");
            modelBuilder.Entity<GameLaunchEvent>().ToTable("GameLaunch", "Events");
            modelBuilder.Entity<StageEndEvent>().ToTable("StageEnd", "Events");
            modelBuilder.Entity<StageEndParameter>().ToTable("StageEnd", "Parameters");
            modelBuilder.Entity<FirstLaunchEvent>().ToTable("FirstLaunch", "Events");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;Port=5432;Database=oidt;User Id=postgres;Password = 123;CommandTimeout=60;");
        }
    }
}