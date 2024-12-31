using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.CustomerService.Interfaces;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerUpdate : ICustomerUpdate
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
