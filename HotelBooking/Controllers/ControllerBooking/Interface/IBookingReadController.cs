namespace HotelBooking.Controllers.ControllerBooking.Interface
{
    public interface IBookingReadController
    {
        //void ShowAllBookings();
        void ShowAllActiveBookings();
        void ShowAllDeletedBookings();
        void ShowABookingDetails();

    }
}
