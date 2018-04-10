using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Events;
using Models.Parameters;

namespace Infrastructure.Configuration
{
    public class Configuration
    {
        public static void ConfigureStageStartEvent(EntityTypeBuilder<StageStartEvent> entity)
        {
            entity.ToTable("stage_start", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Property(e => e.ParametersId)
                .HasColumnName("parameters_id");

            entity.HasKey(e => e.Id)
                .HasName("pk_stage_start");
        }

        public static void ConfigureStageStartParameters(EntityTypeBuilder<StageStartParameters> entity)
        {
            entity.ToTable("stage_start", "parameters");

            entity.Property(p => p.Id)
                .HasColumnName("id");

            entity.Property(p => p.Stage)
                .HasColumnName("stage");

            entity.HasKey(p => p.Id)
                .HasName("pk_stage_start");

            entity.HasOne(p => p.Event)
                .WithOne(e => e.Parameters)
                .HasForeignKey<StageStartEvent>(e => e.ParametersId)
                .HasConstraintName("parameters_id");
        }

        public static void ConfigureStageEndEvent(EntityTypeBuilder<StageEndEvent> entity)
        {
            entity.ToTable("stage_end", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Property(e => e.ParametersId)
                .HasColumnName("parameters_id");

            entity.HasKey(e => e.Id)
                .HasName("pk_stage_end");
        }

        public static void ConfigureStageEndParameters(EntityTypeBuilder<StageEndParameters> entity)
        {
            entity.ToTable("stage_end", "parameters");

            entity.Property(p => p.Id)
                .HasColumnName("id");

            entity.Property(p => p.Income)
                .HasColumnName("income");

            entity.Property(p => p.Stage)
                .HasColumnName("stage");

            entity.Property(p => p.Time)
                .HasColumnName("time");

            entity.Property(p => p.Win)
                .HasColumnName("win");

            entity.HasKey(p => p.Id)
                .HasName("pk_stage_end");

            entity.HasOne(p => p.Event)
                .WithOne(e => e.Parameters)
                .HasForeignKey<StageEndEvent>(e => e.ParametersId)
                .HasConstraintName("parameters_id");
        }

        public static void ConfigureInGamePurchaseEvent(EntityTypeBuilder<InGamePurchaseEvent> entity)
        {
            entity.ToTable("in_game_purchase", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Property(e => e.ParametersId)
                .HasColumnName("parameters_id");

            entity.HasKey(e => e.Id)
                .HasName("pk_in_game_purchase");
        }

        public static void ConfigureInGamePurchaseParameters(EntityTypeBuilder<InGamePurchaseParameters> entity)
        {
            entity.ToTable("in_game_purchase", "parameters");

            entity.Property(p => p.Id)
                .HasColumnName("id");

            entity.Property(p => p.Item)
                .HasColumnName("item");

            entity.Property(p => p.Price)
                .HasColumnName("price");

            entity.HasKey(p => p.Id)
                .HasName("pk_in_game_purchase");

            entity.HasOne(p => p.Event)
                .WithOne(e => e.Parameters)
                .HasForeignKey<InGamePurchaseEvent>(e => e.ParametersId)
                .HasConstraintName("parameters_id");
        }

        public static void ConfigureGameLaunchEvent(EntityTypeBuilder<GameLaunchEvent> entity)
        {
            entity.ToTable("game_launch", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Ignore(e => e.ParametersId);

            entity.HasKey(e => e.Id)
                .HasName("pk_game_launch");
        }

        public static void ConfigureFirstLaunchEvent(EntityTypeBuilder<FirstLaunchEvent> entity)
        {
            entity.ToTable("first_launch", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Property(e => e.ParametersId)
                .HasColumnName("parameters_id");

            entity.HasKey(e => e.Id)
                .HasName("pk_first_launch");
        }

        public static void ConfigureFirstLaunchParameters(EntityTypeBuilder<FirstLaunchParameters> entity)
        {
            entity.ToTable("first_launch", "parameters");

            entity.Property(p => p.Id)
                .HasColumnName("id");

            entity.Property(p => p.Age)
                .HasColumnName("age");

            entity.Property(p => p.Country)
                .HasColumnName("country");

            entity.Property(p => p.Gender)
                .HasColumnName("gender");

            entity.HasKey(p => p.Id)
                .HasName("pk_first_launch");

            entity.HasOne(p => p.Event)
                .WithOne(e => e.Parameters)
                .HasForeignKey<FirstLaunchEvent>(e => e.ParametersId)
                .HasConstraintName("parameters_id");
        }

        public static void ConfigureCurrencyPurchaseEvent(EntityTypeBuilder<CurrencyPurchaseEvent> entity)
        {
            entity.ToTable("currency_purchase", "events");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Udid)
                .HasColumnName("udid");

            entity.Property(e => e.ParametersId)
                .HasColumnName("parameters_id");

            entity.HasKey(e => e.Id)
                .HasName("pk_currency_purchase");
        }

        public static void ConfigureCurrencyPurchaseParameters(EntityTypeBuilder<CurrencyPurchaseParameters> entity)
        {
            entity.ToTable("currency_purchase", "parameters");

            entity.Property(p => p.Id)
                .HasColumnName("id");

            entity.Property(p => p.Income)
                .HasColumnName("income");

            entity.Property(p => p.Name)
                .HasColumnName("name");

            entity.Property(p => p.Price)
                .HasColumnName("price");

            entity.HasKey(p => p.Id)
                .HasName("pk_currency_purchase");

            entity.HasOne(p => p.Event)
                .WithOne(e => e.Parameters)
                .HasForeignKey<CurrencyPurchaseEvent>(e => e.ParametersId)
                .HasConstraintName("parameters_id");
        }
    }
}