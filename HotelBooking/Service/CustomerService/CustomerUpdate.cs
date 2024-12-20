using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerUpdate
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Update
        public Customer ReturnCustomerWithId(int id)
        {
           return _dbContext.Customers.First(c => c.Id == id);
        }
        public void TakeBackSoftDeletedCustomer()
        {
            
        }
    }
}
