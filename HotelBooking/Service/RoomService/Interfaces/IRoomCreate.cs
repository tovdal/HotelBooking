using HotelBooking.Models;

namespace HotelBooking.Service.RoomService.Interfaces
{
    public interface IRoomCreate
    {
        void AddRoom(Room newRoom);
        bool RoomExists(int roomNumber);
    }
}