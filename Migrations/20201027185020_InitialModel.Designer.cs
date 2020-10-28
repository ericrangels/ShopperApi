﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopperApi.Data;

namespace ShopperApi.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20201027185020_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopperApi.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerid");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("pwd")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ShopperApi.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateBirth");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
