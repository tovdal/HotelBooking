using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerCreate
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Create
        public void AddCustomer(Customer newCustomer)
        {
            _dbContext.Add(newCustomer);
            _dbContext.SaveChanges();
        }
    }
}
