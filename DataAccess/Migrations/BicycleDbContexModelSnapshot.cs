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
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.Models.Bicycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brakes")
                        .HasMaxLength(100);

                    b.Property<int>("Brand")
                        .HasMaxLength(50);

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

                    b.Property<string>("Handlebar")
                        .HasMaxLength(100);

                    b.Property<string>("Image");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("Prize");

                    b.Property<int>("Quantity");

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

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("DomainModels.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActiv");

                    b.Property<bool>("IsFinishe");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderUserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DomainModels.Models.OrderBicycle", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId");

                    b.Property<int?>("OrderId1");

                    b.HasKey("OrderId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("OrderId1");

                    b.ToTable("OrderBicycle");
                });

            modelBuilder.Entity("DomainModels.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            Phone = "111111111",
                            Role = "BaseAdmin"
                        });
                });

            modelBuilder.Entity("DomainModels.Models.Order", b =>
                {
                    b.HasOne("DomainModels.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.Models.OrderBicycle", b =>
                {
                    b.HasOne("DomainModels.Models.Bicycle", "Bicycle")
                        .WithMany("OrdersBicycle")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModels.Models.Order", "Order")
                        .WithMany("OrderBicycles")
                        .HasForeignKey("OrderId1");
                });
#pragma warning restore 612, 618
        }
    }
}
