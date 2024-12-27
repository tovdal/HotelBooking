using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers
{
    public class BookingController : IBookingController
    {
        private readonly IBookingCreateController _bookingCreateController;
        private readonly IBookingReadController _bookingReadController;

        public BookingController
            (IBookingCreateController bookingCreateController,
            IBookingReadController bookingReadController)
        {
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
            throw new NotImplementedException();
        }

        public void DeleteABooking()
        {
            throw new NotImplementedException();
        }

        public void TakeBackDeletedBooking()
        {
            throw new NotImplementedException();
        }
        
    }
}