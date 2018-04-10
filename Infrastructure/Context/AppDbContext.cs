using Microsoft.EntityFrameworkCore;
using Models.Events;
using Models.Parameters;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<CurrencyPurchaseParameters> CurrencyPurchaseParameters { get; set; }
        public DbSet<FirstLaunchParameters> FirstLaunchParameters { get; set; }
        public DbSet<InGamePurchaseParameters> InGamePurchaseParameters { get; set; }
        public DbSet<StageStartParameters> StageStartParameters { get; set; }
        public DbSet<StageEndParameters> StageEndParameters { get; set; }
        public DbSet<CurrencyPurchaseEvent> CurrencyPurchaseEvents { get; set; }
        public DbSet<FirstLaunchEvent> FirstLaunchEvents { get; set; }
        public DbSet<InGamePurchaseEvent> InGamePurchaseEvents { get; set; }
        public DbSet<StageEndEvent> StageEndEvents { get; set; }
        public DbSet<StageStartEvent> StageStartEvents { get; set; }
        public DbSet<GameLaunchEvent> GameLaunchEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyPurchaseParameters>(Configuration.Configuration
                .ConfigureCurrencyPurchaseParameters);
            modelBuilder.Entity<CurrencyPurchaseEvent>(Configuration.Configuration.ConfigureCurrencyPurchaseEvent);

            modelBuilder.Entity<FirstLaunchParameters>(Configuration.Configuration.ConfigureFirstLaunchParameters);
            modelBuilder.Entity<FirstLaunchEvent>(Configuration.Configuration.ConfigureFirstLaunchEvent);

            modelBuilder.Entity<GameLaunchEvent>(Configuration.Configuration.ConfigureGameLaunchEvent);

            modelBuilder.Entity<InGamePurchaseParameters>(Configuration.Configuration
                .ConfigureInGamePurchaseParameters);
            modelBuilder.Entity<InGamePurchaseEvent>(Configuration.Configuration.ConfigureInGamePurchaseEvent);

            modelBuilder.Entity<StageEndParameters>(Configuration.Configuration.ConfigureStageEndParameters);
            modelBuilder.Entity<StageEndEvent>(Configuration.Configuration.ConfigureStageEndEvent);

            modelBuilder.Entity<StageStartParameters>(Configuration.Configuration.ConfigureStageStartParameters);
            modelBuilder.Entity<StageStartEvent>(Configuration.Configuration.ConfigureStageStartEvent);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    "Server=localhost;Port=5432;Database=oidt;User Id=postgres;Password = 123;CommandTimeout=60;");
        }
    }
}