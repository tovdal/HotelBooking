using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.BookingService
{
    public class BookingCreate
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddBooking(Booking newBooking)
        {
            _dbContext.Add(newBooking);
            _dbContext.SaveChanges();
        }

        public bool BookingExists(int bookingId)
        {
            return _dbContext.Booking
                .Any(booking => booking.Id == bookingId);
        }

        public bool IsRoomTaken(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            return _dbContext.Set<Booking>()
                .Include(booking => booking.Rooms)
                .Any(booking =>
                    booking.Rooms.Any(room => room.RoomNumber == roomNumber) &&
                    booking.CheckInDate < checkOutDate &&
                    booking.CheckOutDate > checkInDate);
        }
    }
}