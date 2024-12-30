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
        public Customer ReturnCustomerWithId(int id)
        {
           return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
