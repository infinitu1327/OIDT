﻿// <auto-generated />

using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    internal class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Lab1.Models.Events.CurrencyPurchaseEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId")
                    .IsUnique();

                b.ToTable("CurrencyPurchaseEvents");
            });

            modelBuilder.Entity("Lab1.Models.Events.FirstLaunchEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId")
                    .IsUnique();

                b.ToTable("FirstLaunchEvents");
            });

            modelBuilder.Entity("Lab1.Models.Events.GameLaunchEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.ToTable("GameLaunchEvents");
            });

            modelBuilder.Entity("Lab1.Models.Events.InGamePurchaseEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId")
                    .IsUnique();

                b.ToTable("InGamePurchaseEvents");
            });

            modelBuilder.Entity("Lab1.Models.Events.StageEndEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId")
                    .IsUnique();

                b.ToTable("StageEndEvents");
            });

            modelBuilder.Entity("Lab1.Models.Events.StageStartEvent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId")
                    .IsUnique();

                b.ToTable("StageStartEvents");
            });

            modelBuilder.Entity("Lab1.Models.Parameters.CurrencyPurchaseParameter", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("Income");

                b.Property<string>("Name");

                b.Property<decimal>("Price");

                b.HasKey("Id");

                b.ToTable("CurrencyPurchaseParameters");
            });

            modelBuilder.Entity("Lab1.Models.Parameters.FirstLaunchParameter", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("Age");

                b.Property<string>("Country");

                b.Property<string>("Gender");

                b.HasKey("Id");

                b.ToTable("FirstLaunchParameters");
            });

            modelBuilder.Entity("Lab1.Models.Parameters.InGamePurchaseParameter", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Item");

                b.Property<int>("Price");

                b.HasKey("Id");

                b.ToTable("InGamePurchaseParameters");
            });

            modelBuilder.Entity("Lab1.Models.Parameters.StageEndParameter", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("Income");

                b.Property<int>("Stage");

                b.Property<int>("Time");

                b.Property<bool>("Win");

                b.HasKey("Id");

                b.ToTable("StageEndParameters");
            });

            modelBuilder.Entity("Lab1.Models.Parameters.StageStartParameter", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("Stage");

                b.HasKey("Id");

                b.ToTable("StageStartParameters");
            });

            modelBuilder.Entity("Lab1.Models.Events.CurrencyPurchaseEvent", b =>
            {
                b.HasOne("Lab1.Models.Parameters.CurrencyPurchaseParameter", "Parameters")
                    .WithOne("Event")
                    .HasForeignKey("Lab1.Models.Events.CurrencyPurchaseEvent", "ParametersId");
            });

            modelBuilder.Entity("Lab1.Models.Events.FirstLaunchEvent", b =>
            {
                b.HasOne("Lab1.Models.Parameters.FirstLaunchParameter", "Parameters")
                    .WithOne("Event")
                    .HasForeignKey("Lab1.Models.Events.FirstLaunchEvent", "ParametersId");
            });

            modelBuilder.Entity("Lab1.Models.Events.InGamePurchaseEvent", b =>
            {
                b.HasOne("Lab1.Models.Parameters.InGamePurchaseParameter", "Parameters")
                    .WithOne("Event")
                    .HasForeignKey("Lab1.Models.Events.InGamePurchaseEvent", "ParametersId");
            });

            modelBuilder.Entity("Lab1.Models.Events.StageEndEvent", b =>
            {
                b.HasOne("Lab1.Models.Parameters.StageEndParameter", "Parameters")
                    .WithOne("Event")
                    .HasForeignKey("Lab1.Models.Events.StageEndEvent", "ParametersId");
            });

            modelBuilder.Entity("Lab1.Models.Events.StageStartEvent", b =>
            {
                b.HasOne("Lab1.Models.Parameters.StageStartParameter", "Parameters")
                    .WithOne("Event")
                    .HasForeignKey("Lab1.Models.Events.StageStartEvent", "ParametersId");
            });
#pragma warning restore 612, 618
        }
    }
}