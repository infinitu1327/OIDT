﻿// <auto-generated />

using System;
using Lab1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    internal class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab1.Models.Event", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<int>("EventId");

                b.Property<int?>("ParametersId");

                b.Property<string>("Udid");

                b.HasKey("Id");

                b.HasIndex("ParametersId");

                b.ToTable("Events");
            });

            modelBuilder.Entity("Lab1.Models.Parameters", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Discriminator")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("Parameters");

                b.HasDiscriminator<string>("Discriminator").HasValue("Parameters");
            });

            modelBuilder.Entity("Lab1.Models.CurrencyPurchaseParameters", b =>
            {
                b.HasBaseType("Lab1.Models.Parameters");

                b.Property<int>("Income");

                b.Property<string>("Name");

                b.Property<decimal>("Price");

                b.ToTable("CurrencyPurchaseParameters");

                b.HasDiscriminator().HasValue("CurrencyPurchaseParameters");
            });

            modelBuilder.Entity("Lab1.Models.FirstLaunchParameters", b =>
            {
                b.HasBaseType("Lab1.Models.Parameters");

                b.Property<int>("Age");

                b.Property<string>("Country");

                b.Property<string>("Gender");

                b.ToTable("FirstLaunchParameters");

                b.HasDiscriminator().HasValue("FirstLaunchParameters");
            });

            modelBuilder.Entity("Lab1.Models.InGamePurchaseParameters", b =>
            {
                b.HasBaseType("Lab1.Models.Parameters");

                b.Property<string>("Item");

                b.Property<int>("Price")
                    .HasColumnName("InGamePurchaseParameters_Price");

                b.ToTable("InGamePurchaseParameters");

                b.HasDiscriminator().HasValue("InGamePurchaseParameters");
            });

            modelBuilder.Entity("Lab1.Models.StageEndParameters", b =>
            {
                b.HasBaseType("Lab1.Models.Parameters");

                b.Property<int?>("Income")
                    .HasColumnName("StageEndParameters_Income");

                b.Property<int>("Stage");

                b.Property<int>("Time");

                b.Property<bool>("Win");

                b.ToTable("StageEndParameters");

                b.HasDiscriminator().HasValue("StageEndParameters");
            });

            modelBuilder.Entity("Lab1.Models.StageStartParameters", b =>
            {
                b.HasBaseType("Lab1.Models.Parameters");

                b.Property<int>("Stage")
                    .HasColumnName("StageStartParameters_Stage");

                b.ToTable("StageStartParameters");

                b.HasDiscriminator().HasValue("StageStartParameters");
            });

            modelBuilder.Entity("Lab1.Models.Event", b =>
            {
                b.HasOne("Lab1.Models.Parameters", "Parameters")
                    .WithMany()
                    .HasForeignKey("ParametersId");
            });
#pragma warning restore 612, 618
        }
    }
}