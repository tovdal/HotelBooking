using HotelBooking.Models;

namespace HotelBooking.Service.BookingService.Interfaces
{
    public interface IBookingUpdate
    {
        Booking ReturnBookingWithId(int id);
        void SaveChanges();
    }
}