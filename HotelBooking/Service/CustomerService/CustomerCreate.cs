using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerCreate
    {
        private readonly HotelBookingDbContext _dbContext;

        public CustomerCreate(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Create
        public void AddCustomer(Customer newCustomer)
        {
            _dbContext.Add(newCustomer);
            //dbContext.SaveChanges(); // the dbContext not created yet
        }
    }
}
