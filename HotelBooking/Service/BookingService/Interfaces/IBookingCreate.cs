using HotelBooking.Models;

namespace HotelBooking.Service.BookingService.Interfaces
{
    public interface IBookingCreate
    {
        void AddBooking(Booking newBooking);
        bool BookingExists(int bookingId);
        List<Room> GetRoomsToBook();
        decimal TotalPriceOfBooking(DateTime checkInDate, DateTime checkOutDate);
        bool IsRoomBooked(int roomNumber, DateTime checkInDate, DateTime checkOutDate);
        void AddRoomToBooking(string roomNumber, bool extraBed = false);
        void ClearRoomsToBook();
    }
}