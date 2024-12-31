using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

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
        DisplayBookingInformation.PrintBookingAndInvoice
            (bookings, "There are no bookings registered");
        ConsoleMessagePrinter.DisplayMessage();

    }
    public void ShowAllDeletedBookings()
    {
        var bookings = _bookingRead.GetBookingsDeleted();
        DisplayBookingInformation.PrintBookingDeleted
            (bookings, "There are no deleted bookings");
        ConsoleMessagePrinter.DisplayMessage();
    }
    public void ShowABookingDetails()
    {
        bool isSearching = true;
        while (isSearching)
        {
            Console.Clear();
            var bookings = _bookingRead.GetAllActiveBookings().ToList();
            DisplayBookingInformation.PrintBookingIdAndCustomerID
                (bookings, "There are no bookings registered. " +
                "(Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(bookings))
            {
                isSearching = false;
                return;
            }
            if (!ValidatorBooking.TryGetBookingId(out int bookingId))
            {
                isSearching = false;
                return;
            }

            var booking = _bookingRead.GetBookingDetails(bookingId).FirstOrDefault();

            if (booking == null)
            {
                AnsiConsole.MarkupLine($"[bold red]No booking found with ID number:" +
                    $" {bookingId}.[/]");
                Console.ReadKey();
                continue;
            }
            if (!ValidatorBooking.IsBookingDeleted(booking, bookingId))
            {
                isSearching = false;
                return;
            }

            DisplayBookingInformation.PrintBookingAll
                (new List<Booking> { booking }, 
                $"No booking found with Id: {bookingId}.");
            ConsoleMessagePrinter.DisplayMessage();
            isSearching = false;
        }
    }
}