using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Service.BookingService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Validators;

namespace HotelBooking.Controllers.ControllerBooking;

public class BookingReadController : IBookingReadController
{
    private readonly BookingRead _bookingRead;
    public BookingReadController(BookingRead bookingRead)
    {
        _bookingRead = bookingRead;
    }
    public void ShowAllActiveBookings()
    {
        var bookings = _bookingRead.GetAllActiveBookings().ToList();
        DisplayBookingInformation.PrintBookingAndInvoice(bookings);
        ConsoleMessagePrinter.DisplayMessage();

    }
    public void ShowAllDeletedBookings()
    {
        var bookings = _bookingRead.GetBookingsDeleted();
        DisplayBookingInformation.PrintBookingDeleted(bookings);
        ConsoleMessagePrinter.DisplayMessage();
    }
    public void ShowABookingDetails()
    {
        bool isSearching = true;
        while (isSearching)
        {
            Console.Clear();
            var bookings = _bookingRead.GetAllActiveBookings().ToList();
            DisplayBookingInformation.PrintBookingIdAndCustomerID(bookings);

            if (!ValidatorBookingId.TryGetBookingId(out int bookingId))
            {
                continue;
            }
            var booking = _bookingRead.GetBookingDetails(bookingId);
            DisplayBookingInformation.PrintBookingAll
                (booking, $"No booking found with Id: {bookingId}.");
            ConsoleMessagePrinter.DisplayMessage();
            isSearching = false;
        }
    }
}