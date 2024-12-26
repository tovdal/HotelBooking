using HotelBooking.Data;

namespace HotelBooking.Service.CustomerService
{
    public class CustomerDelete
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerDelete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool HasCustomerBooking(int customerId)
        {
            return _dbContext.Customers
                .Any(c => c.Id == customerId && c.Bookings.Any());
        }
    }
}
