using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers
{
    public class BookingController : IBookingController
    {
        private readonly IBookingCreateController _bookingCreateController;
        private readonly IBookingReadController _bookingReadController;
        private readonly IBookingUpdateController _bookingUpdateController;

        public BookingController
            (IBookingCreateController bookingCreateController,
            IBookingReadController bookingReadController,
            IBookingUpdateController bookingUpdateController)
        {
            _bookingUpdateController = bookingUpdateController;
            _bookingCreateController = bookingCreateController;
            _bookingReadController = bookingReadController;
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
            throw new NotImplementedException();
        }

        public void TakeBackDeletedBooking()
        {
            _bookingUpdateController.TakeBackDeletedBooking();
        }
    }
}