﻿using HotelBooking.Config;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Service.CustomerService

{
    public class CustomerRead
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRead(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Console.WriteLine("DbContext is configured: " + (_dbContext != null));
        }
        //Read
        public IQueryable<Customer> GetAllCustomersInDatabase()
        {
            return _dbContext.Customers
                .Include(c => c.Bookings!)
                .ThenInclude(b => b.Rooms);
        }
        public IQueryable<Customer> GetAllActiveCustomerInDatabase()
        {
            return _dbContext.Customers
                .Where(g => g.IsCustomerStatusActive);
        }

        public IQueryable<Customer> GetAllInactiveCustomersInDatabase()
        {
            return _dbContext.Customers
                .Where(g => !g.IsCustomerStatusActive);
        }

        public IQueryable<Customer> GetAllDeletedCustomersInDatabase()
        {
            return _dbContext.Customers
                .Where(g => g.IsCustomerDeleted)
                ;
        }
        public IQueryable<Customer> GetCustomerDetailes(int id)
        {
            return _dbContext.Customers
                .Where(g => g.Id == id);
        }
        public bool GetCustomersIsDeleted()
        {
            return _dbContext.Customers
                .Any(c => c.IsCustomerDeleted);
        }
    }
}