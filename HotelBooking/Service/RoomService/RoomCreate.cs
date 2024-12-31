using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.RoomService.Interfaces;

namespace HotelBooking.Service.RoomService
{
    public class RoomCreate : IRoomCreate
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRoom(Room newRoom)
        {
            _dbContext.Add(newRoom);
            _dbContext.SaveChanges();
        }
        public bool RoomExists(int roomNumber)
        {
            return _dbContext.Rooms
                .Any(room => room.RoomNumber == roomNumber);
        }
    }
}