namespace HotelBooking.Controllers.ControllerRooms.Interface
{
    public interface IRoomReadController
    {
        void ShowAllRooms();
        void ShowAllDeletedRooms();
        void ShowAllAvailableRooms();
        void ShowARoomDetailes();
    }
}