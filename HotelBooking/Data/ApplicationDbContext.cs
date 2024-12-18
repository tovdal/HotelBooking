﻿using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("server=localhost;initial catalog=HotelbookingDB;Trusted_Connection=True;TrustServerCertificate=true");
        //    }
        //}
    }
}
