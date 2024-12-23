namespace HotelBooking.Controllers.Interfaces
{
    public interface IBookingController
    {
        void CreateBooking();
        void ReadAllBookings();
        void ReadAllDeleted();
        void ReadABooking();
        void UpdateABooking();
        void DeleteABooking();
        void TakeBackDeletedBooking();
    }
}
