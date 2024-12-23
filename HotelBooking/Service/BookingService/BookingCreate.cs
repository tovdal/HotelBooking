using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.BookingService
{
    public class BookingCreate
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCustomer(Booking newBooking)
        {
            _dbContext.Add(newBooking);
            _dbContext.SaveChanges();
        }
    }
}