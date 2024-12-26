using HotelBooking.Config;
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
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _dbContext.Customers
                .Where(c => !c.IsCustomerDeleted);
        }

        public bool CustomerExists(int customerId)
        {
            return _dbContext.Customers
                .Any(c => c.Id == customerId && !c.IsCustomerDeleted);
        }

        public IQueryable<Customer> GetAllDeletedCustomersInDatabase()
        {
            return _dbContext.Customers
                .Where(g => g.IsCustomerDeleted);
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