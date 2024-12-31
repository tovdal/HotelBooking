using HotelBooking.Models;

namespace HotelBooking.Service.RoomService.Interfaces
{
    public interface IRoomRead
    {
        List<Room> GetAllRoomsInDb();
        IQueryable<Room> GetAllActiveRooms();
        IQueryable<Room> GetAllAvailableRooms();
        IQueryable<Room> GetAllAvailablebookingRooms
            (DateTime checkInDate, DateTime checkOutDate);
        IQueryable<Room> GetRoomDetails(int id);
        IQueryable<Room> GetAllDeletedRoomsInDatabase();
        Room GetRoomByRoomNumber(int roomNumber);
        bool GetRoomByExtraBed(int roomNumber);
        bool IsRoomBooked
            (int roomNumber, DateTime checkInDate, DateTime checkOutDate);
        bool IsRoomDeleted(int roomNumber);
    }
}