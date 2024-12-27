using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelBooking.Service.BookingService
{
    public class BookingRead
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingRead(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetAllBookingsInDb()
        {
            return _dbContext.Bookings.ToList();
        }

        public IEnumerable<Booking> GetAllActiveBookings()
        {
            return _dbContext.Bookings
                .Where(b => b.Status == StatusOnBooking.Active)
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
                .Where(b => b.Status == StatusOnBooking.Deleted);
        }
    }
}
