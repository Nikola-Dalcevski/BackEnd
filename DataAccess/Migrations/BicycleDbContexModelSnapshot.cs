﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(BicycleDbContex))]
    partial class BicycleDbContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.Models.BaseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("BaseUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUser");
                });

            modelBuilder.Entity("DomainModels.Models.Bicycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brakes")
                        .HasMaxLength(100);

                    b.Property<int>("Brand");

                    b.Property<string>("Cassate")
                        .HasMaxLength(100);

                    b.Property<string>("Chain")
                        .HasMaxLength(100);

                    b.Property<string>("Cruncset")
                        .HasMaxLength(100);

                    b.Property<string>("Fork")
                        .HasMaxLength(100);

                    b.Property<string>("Frame")
                        .HasMaxLength(100);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Handlebar")
                        .HasMaxLength(100);

                    b.Property<string>("Images")
                        .HasMaxLength(100);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("OrderId");

                    b.Property<double>("Prize");

                    b.Property<string>("RearDeraillerur")
                        .HasMaxLength(100);

                    b.Property<string>("RearHub")
                        .HasMaxLength(100);

                    b.Property<string>("Seat")
                        .HasMaxLength(100);

                    b.Property<string>("TireInfo")
                        .HasMaxLength(100);

                    b.Property<string>("TireSize")
                        .HasMaxLength(100);

                    b.Property<int>("Type");

                    b.Property<string>("Weight")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("DomainModels.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DeleveryDate");

                    b.Property<string>("OrderAddress")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("OrderCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderUserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DomainModels.Models.Admin", b =>
                {
                    b.HasBaseType("DomainModels.Models.BaseUser");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new { Id = 1, Email = "Admin@gmail.com", Name = "Admin", Password = "123456", Phone = "111111111" }
                    );
                });

            modelBuilder.Entity("DomainModels.Models.Customer", b =>
                {
                    b.HasBaseType("DomainModels.Models.BaseUser");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.ToTable("Customer");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("DomainModels.Models.Bicycle", b =>
                {
                    b.HasOne("DomainModels.Models.Order")
                        .WithMany("Bicycles")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("DomainModels.Models.Order", b =>
                {
                    b.HasOne("DomainModels.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DomainModels.Models.BaseUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
