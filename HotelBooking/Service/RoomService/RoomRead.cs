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
        public List<Room> GetAllRoomsInDb()
        {
            return _dbContext.Rooms
                .OrderBy(r => r.RoomNumber)
                .ToList();
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
        public IQueryable<Room> GetAllAvailablebookingRooms
            (DateTime checkInDate, DateTime checkOutDate)
        {
            return _dbContext.Rooms
                .Where(r => !r.IsRoomDeleted && r.IsAvailable && r.Bookings
                    .All(b => b.Status == BookingStatus.Deleted 
                    || b.CheckOutDate <= checkInDate 
                    || b.CheckInDate >= checkOutDate))
                .OrderBy(r => r.RoomNumber);
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
                .Any(r => r.IsRoomDeleted);
        }
        public Room GetRoomByRoomNumber(int roomNumber)
        {
            return _dbContext.Rooms
                .FirstOrDefault(r => r.RoomNumber == roomNumber);
        }
        public bool GetRoomByExtraBed(int roomNumber)
        {
            return _dbContext.Rooms
                .Any(r => r.RoomNumber == roomNumber && r.IsExtraBedAvailable);
        }
        public bool IsRoomBooked
            (int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            return _dbContext.Bookings
                .Any(b => b.Rooms.Any(r => r.RoomNumber == roomNumber)
                          && b.Status != BookingStatus.Deleted
                          && b.CheckInDate < checkOutDate
                          && b.CheckOutDate > checkInDate);
        }
        public bool IsRoomDeleted(int roomNumber)
        {
            return _dbContext.Rooms
                .Any(r => r.RoomNumber == roomNumber && r.IsRoomDeleted);
        }
    }
}