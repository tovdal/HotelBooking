using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.BookingService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.BookingService
{
    public class BookingRead : IBookingRead
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingRead(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetAllBookingsInDb()
        {
            return _dbContext.Bookings
                .OrderBy(b => b.Id)
                .ToList();
        }

        public IEnumerable<Booking> GetAllActiveBookings()
        {
            return _dbContext.Bookings
                .Where(b => b.Status == BookingStatus.Active)
                .Include(b => b.Invoice)
                .Include(b => b.Rooms)
                .Include(b => b.Customer)
                .OrderBy(b => b.Id)
                .ToList();
        }

        public IQueryable<Booking> GetBookingDetails(int id)
        {
            return _dbContext.Bookings
                .Where(b => b.Id == id);
        }

        public IEnumerable<Booking> GetBookingsDeleted()
        {
            return _dbContext.Bookings
                .Where(b => b.Status == BookingStatus.Deleted);
        }
    }
}
