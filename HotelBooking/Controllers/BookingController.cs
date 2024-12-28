using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers
{
    public class BookingController : IBookingController
    {
        private readonly IBookingCreateController _bookingCreateController;
        private readonly IBookingReadController _bookingReadController;
        private readonly IBookingUpdateController _bookingUpdateController;
        private readonly IBookingDeleteController _bookingDeleteController;

        public BookingController
            (IBookingCreateController bookingCreateController,
            IBookingReadController bookingReadController,
            IBookingUpdateController bookingUpdateController,
            IBookingDeleteController bookingDeleteController)
        {
            _bookingUpdateController = bookingUpdateController;
            _bookingCreateController = bookingCreateController;
            _bookingReadController = bookingReadController;
            _bookingDeleteController = bookingDeleteController;
        }

        public void CreateBooking()
        {
            _bookingCreateController.CreateBooking();
        }
        public void ReadAllBookings()
        {
            _bookingReadController.ShowAllActiveBookings();
        }

        public void ReadABooking()
        {
            _bookingReadController.ShowABookingDetails();
        }

        public void ReadAllDeleted()
        {
            _bookingReadController.ShowAllDeletedBookings();
        }

        public void UpdateABooking()
        {
            _bookingUpdateController.UpdateBookingInformation();
        }

        public void DeleteABooking()
        {
            _bookingDeleteController.DeleteBooking();
        }
    }
}