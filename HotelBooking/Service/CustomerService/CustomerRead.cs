using HotelBooking.Data;
using HotelBooking.Models;
namespace HotelBooking.Service.CustomerService

{
    public class CustomerRead
    {
        private readonly HotelBookingDbContext _dbContext;

        public CustomerRead(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Read
        public List<Customer> GetAllCustomersInDatabase()
        {
            return _dbContext.Customers.ToList();
        }
        public List<Customer> GetAllActiveCustomerInDatabase()
        {
            return _dbContext.Customers.Where(g => g.IsCustomerStatusActive).ToList();
        }

        public List<Customer> GetAllInactiveCustomersInDatabase()
        {
            return _dbContext.Customers.Where(g => !g.IsCustomerStatusActive).ToList();
        }

        public List<Customer> GetAllDeletedCustomersInDatabase()
        {
            return _dbContext.Customers.Where(g => g.IsCustomerDeleted).ToList();
        }
        public List<Customer> GetCustomerDetailes(int id) 
        {
            return _dbContext.Customers.Where(g => g.CustomerId == id).ToList();
        }
    }
}
