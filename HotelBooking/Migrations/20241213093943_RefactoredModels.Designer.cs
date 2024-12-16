﻿// <auto-generated />
using System;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBooking.Migrations
{
    [DbContext(typeof(HotelBookingDbContext))]
    [Migration("20241213093943_RefactoredModels")]
    partial class RefactoredModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelBooking.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCostOfTheBooking")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HotelBooking.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCustomerStatusActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelBooking.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<decimal>("CostAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDateOnInvoice")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelBooking.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExtraBedAvailable")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<byte>("RoomSize")
                        .HasColumnType("tinyint");

                    b.Property<int>("TypeOfRooms")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("BookingId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelBooking.Models.Booking", b =>
                {
                    b.HasOne("HotelBooking.Models.Customer", null)
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("HotelBooking.Models.Room", b =>
                {
                    b.HasOne("HotelBooking.Models.Booking", null)
                        .WithMany("Rooms")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("HotelBooking.Models.Booking", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelBooking.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
