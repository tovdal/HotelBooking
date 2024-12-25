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
            return _dbContext.Bookings
                .Any(booking => booking.Id == bookingId);
        }

        public decimal TotalPriceOfBooking()
        {
            return _dbContext.Bookings
                .Include(booking => booking.Rooms)
                    .Select(booking => new
                    {
                        TotalBookingPrice = booking.Rooms
                        .Sum(room => room.PricePerNight * 
                        (booking.CheckOutDate - booking.CheckInDate).Days)
                    })
        .Sum(booking => booking.TotalBookingPrice);
        }

        public bool IsRoomBooked(int roomNumber)
        {
            var room = _dbContext.Rooms
        .FirstOrDefault(r => r.RoomNumber == roomNumber);

            // If the room doesn't exist, handle accordingly (e.g., throw an exception or return false)
            if (room == null)
            {
                // Handle the case where the room is not found
                // For example, you might throw an exception or return false
                throw new ArgumentException($"Room with number {roomNumber} does not exist.");
            }

            // Check if the room is available
            return room.IsAvailable;
        }
    }
}