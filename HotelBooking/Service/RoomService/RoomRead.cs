using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.RoomService
{
    public class RoomRead
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomRead(ApplicationDbContext dbContext)
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
