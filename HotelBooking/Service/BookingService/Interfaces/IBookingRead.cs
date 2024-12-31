using HotelBooking.Models;

namespace HotelBooking.Service.BookingService.Interfaces
{
    public interface IBookingRead
    {
        List<Booking> GetAllBookingsInDb();
        IEnumerable<Booking> GetAllActiveBookings();
        IQueryable<Booking> GetBookingDetails(int id);
        IEnumerable<Booking> GetBookingsDeleted();
    }
}