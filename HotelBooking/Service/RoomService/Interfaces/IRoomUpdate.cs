using HotelBooking.Models;

namespace HotelBooking.Service.RoomService.Interfaces
{
    public interface IRoomUpdate
    {
        Room ReturnCustomerWithId(int id);
        void UpdateRoomAndBookingAvailability();
        void SaveChanges();
    }
}