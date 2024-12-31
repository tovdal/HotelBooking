using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.CustomerService.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Service.CustomerService
{
    public class CustomerRead : ICustomerRead
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRead(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _dbContext.Customers
                .Include(c => c.Address)
                .Where(c => !c.IsCustomerDeleted)
                .OrderBy(c => c.Id);
        }
        public bool CustomerExists(int customerId)
        {
            return _dbContext.Customers
                .Include(c => c.Address)
                .Any(c => c.Id == customerId && !c.IsCustomerDeleted);
        }
        public IQueryable<Customer> GetAllDeletedCustomersInDatabase()
        {
            return _dbContext.Customers
                .Include(c => c.Address)
                .Where(g => g.IsCustomerDeleted)
                .OrderBy(c => c.Id);
        }
        public IQueryable<Customer> GetCustomerDetailes(int id)
        {
            return _dbContext.Customers
                .Include(c => c.Address)
                .Where(g => g.Id == id);
        }
    }
}