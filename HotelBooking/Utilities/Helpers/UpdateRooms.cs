using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Utilities.Helpers
{
    public class UpdateRooms
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateRooms(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UpdateRoomAvailability()
        {
            var rooms = _dbContext.Rooms.Include(r => r.Bookings).ToList();

            foreach (var room in rooms)
            {
                room.IsAvailable = room.Bookings
                    .All(b => b.Status == BookingStatus.Deleted 
                    || b.CheckOutDate <= DateTime.Now 
                    || b.CheckInDate >= DateTime.Now);
            }

            _dbContext.SaveChanges();
        }
    }
}
