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
        public List<Room> GetAllRoomsInDb()
        {
            return _dbContext.Rooms.ToList();
        }
        public IQueryable<Room> GetAllActiveRooms()
        {
            return _dbContext.Rooms
                .Where(r => !r.IsRoomDeleted)
                .OrderBy(r => r.RoomNumber);
        }

        public IQueryable<Room> GetAllAvailableRooms()
        {
            return _dbContext.Rooms
                .Where(r => !r.IsAvailable)
                .OrderBy(r => r.RoomNumber);

        }
        public IQueryable<Room> GetAllAvailablebookingRooms()
        {
            return _dbContext.Rooms
                .Where(r => r.IsAvailable);
        }
        public IQueryable<Room> GetAllTakenRooms()
        {
            return _dbContext.Rooms
                .Where(r => r.IsAvailable)
                .OrderBy(r => r.RoomNumber);
        }
        public IQueryable<Room> GetRoomDetails(int id)
        {
            return _dbContext.Rooms
                .Where(r => r.Id == id);
        }
        public IQueryable<Room> GetAllDeletedRoomsInDatabase()
        {
            return _dbContext.Rooms
                .Where(r => r.IsRoomDeleted)
                .OrderBy(r => r.RoomNumber);
        }
        public bool GetRoomsIsDeleted()
        {
            return _dbContext.Rooms
                .Any(c => c.IsRoomDeleted);
        }
        public Room GetRoomByRoomNumber(int roomNumber)
        {
            return _dbContext.Rooms
                .First(r => r.RoomNumber == roomNumber);

        }
        public bool GetRoomByExtraBed(int roomNumber)
        {
            return _dbContext.Rooms
                .Any(r => r.RoomNumber == roomNumber && r.IsExtraBedAvailable);
        }
    }
}
