using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.BookingService
{
    public class BookingDelete
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingDelete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasBooking(int customerId)
        {
            return _dbContext.Customers
                .Any(c => c.Id == customerId && c.Bookings.Any());
        }

        public void DeleteBooking(int bookingId)
        {
            var bookingToDelete = _dbContext.Bookings
                .Include(b => b.Rooms)
                .FirstOrDefault(b => b.Id == bookingId);

            if (bookingToDelete != null)
            {
                bookingToDelete.Status = BookingStatus.Deleted;
                foreach (var room in bookingToDelete.Rooms)
                {
                    room.IsAvailable = true;
                    Console.WriteLine($"Room {room.RoomNumber} marked now as available.");
                }
                _dbContext.SaveChanges();
                Console.WriteLine("Changes saved.");
            }
            else
            {
                Console.WriteLine($"No booking found with ID number: {bookingId}.");
            }
        }
    }
}
