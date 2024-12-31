using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.CustomerService.Interfaces;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerCreate : ICustomerCreate
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _dbContext.Add(newCustomer);
            _dbContext.SaveChanges();
        }
    }
}
