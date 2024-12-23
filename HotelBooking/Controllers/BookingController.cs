using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers
{
    public class BookingController : IBookingController
    {
        private readonly IBookingCreateController _bookingCreateController;

        public BookingController
            (IBookingCreateController bookingCreateController)
        {
            _bookingCreateController = bookingCreateController;
        }

        public void CreateBooking()
        {
            _bookingCreateController.CreateBooking();
        }

        public void DeleteABooking()
        {
            throw new NotImplementedException();
        }

        public void ReadABooking()
        {
            throw new NotImplementedException();
        }

        public void ReadAllBookings()
        {
            throw new NotImplementedException();
        }

        public void ReadAllDeleted()
        {
            throw new NotImplementedException();
        }

        public void TakeBackDeletedBooking()
        {
            throw new NotImplementedException();
        }

        public void UpdateABooking()
        {
            throw new NotImplementedException();
        }
    }
}