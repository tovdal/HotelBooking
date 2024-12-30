using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.RoomService
{
    public class RoomUpdate
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomUpdate(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Room ReturnCustomerWithId(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(c => c.Id == id);
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
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
