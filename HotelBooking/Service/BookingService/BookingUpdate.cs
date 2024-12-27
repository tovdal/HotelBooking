using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.BookingService
{
    public class BookingUpdate
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booking ReturnBookingWithId(int id)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
