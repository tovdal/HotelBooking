using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.RoomService
{
    public class RoomRead
    {
        private readonly HotelBookingDbContext _dbContext;

        public RoomRead(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Read
        public List<Room> GetAllRoomsInDatabase()
        {
            return _dbContext.Rooms.ToList();
        }
    }
}
