﻿// <auto-generated />
using Lab1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Lab1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Models.CurrencyPurchaseParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Income");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("CurrencyPurchaseParameters");
                });

            modelBuilder.Entity("Models.DAU", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<int>("Count");

                    b.HasKey("Date");

                    b.ToTable("DAU");
                });

            modelBuilder.Entity("Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<short>("EventId");

                    b.Property<int>("ParametersId");

                    b.Property<string>("Udid");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Models.FirstLaunchParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Country");

                    b.Property<string>("Gender");

                    b.HasKey("Id");

                    b.ToTable("FirstLaunchParameters");
                });

            modelBuilder.Entity("Models.GameLaunchParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("GameLaunchParameters");
                });

            modelBuilder.Entity("Models.InGamePurchaseParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Item");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("InGamePurchaseParameters");
                });

            modelBuilder.Entity("Models.Revenue", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Income");

                    b.HasKey("Date");

                    b.ToTable("Revenue");
                });

            modelBuilder.Entity("Models.StageEndParameters", b =>
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

            modelBuilder.Entity("Models.StageStartParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Stage");

                    b.HasKey("Id");

                    b.ToTable("StageStartParameters");
                });

            modelBuilder.Entity("Models.UniqueUsers", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<int>("Count");

                    b.HasKey("Date");

                    b.ToTable("UniqueUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
