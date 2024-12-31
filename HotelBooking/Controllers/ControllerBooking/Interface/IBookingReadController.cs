namespace HotelBooking.Controllers.ControllerBooking.Interface
{
    public interface IBookingReadController
    {
        void ShowAllActiveBookings();
        void ShowAllDeletedBookings();
        void ShowABookingDetails();

    }
}
