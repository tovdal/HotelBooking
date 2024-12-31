using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.BookingService.Interfaces;

namespace HotelBooking.Service.BookingService
{
    public class BookingUpdate : IBookingUpdate
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
