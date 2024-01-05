﻿// <auto-generated />
using System;
using BTRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"), 1L, 1);

                    b.Property<string>("CptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NOofSeats")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.ToTable("bus");
                });

            modelBuilder.Entity("BTRS.Models.Bus_busTrips", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BusId");

                    b.HasIndex("TripId");

                    b.ToTable("Bus_busTrips");
                });

            modelBuilder.Entity("BTRS.Models.BusTrip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"), 1L, 1);

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripId");

                    b.HasIndex("AdminID");

                    b.ToTable("busTrip");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("BTRS.Models.passengers_trips", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TripId");

                    b.ToTable("passengers_trips");
                });

            modelBuilder.Entity("BTRS.Models.Bus_busTrips", b =>
                {
                    b.HasOne("BTRS.Models.Bus", "bus")
                        .WithMany("bus_trips")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.BusTrip", "trip")
                        .WithMany("bus_trips")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bus");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.BusTrip", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "admin")
                        .WithMany("trips")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");
                });

            modelBuilder.Entity("BTRS.Models.passengers_trips", b =>
                {
                    b.HasOne("BTRS.Models.Passenger", "passenger")
                        .WithMany("passengers_trips")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.BusTrip", "trip")
                        .WithMany("passengers_trips")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Navigation("trips");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.Navigation("bus_trips");
                });

            modelBuilder.Entity("BTRS.Models.BusTrip", b =>
                {
                    b.Navigation("bus_trips");

                    b.Navigation("passengers_trips");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Navigation("passengers_trips");
                });
#pragma warning restore 612, 618
        }
    }
}
