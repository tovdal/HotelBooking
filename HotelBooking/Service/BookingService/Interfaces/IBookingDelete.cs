namespace HotelBooking.Service.BookingService.Interfaces
{
    public interface IBookingDelete
    {
        bool HasBooking(int customerId);
        void DeleteBooking(int bookingId);
    }
}