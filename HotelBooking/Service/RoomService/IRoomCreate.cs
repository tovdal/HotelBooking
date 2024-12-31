using HotelBooking.Models;

namespace HotelBooking.Service.RoomService
{
    public interface IRoomCreate
    {
        void AddRoom(Room newRoom);
        bool RoomExists(int roomNumber);
    }
}