using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Service.BookingService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking
{
    public class BookingDeleteController : IBookingDeleteController
    {
        private readonly BookingRead _bookingRead;
        private readonly BookingUpdate _bookingUpdate;
        private readonly BookingDelete _bookingDelete;
        public BookingDeleteController(BookingRead bookingRead,
            BookingUpdate bookingUpdate,
            BookingDelete bookingDelete)
        {
            _bookingRead = bookingRead;
            _bookingUpdate = bookingUpdate;
            _bookingDelete = bookingDelete;
        }
        public void DeleteBooking()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var bookings = _bookingRead.GetAllActiveBookings()
                    .ToList();
                DisplayBookingInformation.PrintBookingIdAndCustomerID
                    (bookings, "There are no bookings registered");
                if (bookings.Count == 0)
                {
                    Console.ReadKey();
                    return;
                }
                if (!ValidatorBookingId.TryGetBookingId(out int bookingId))
                {
                    return;
                }
                var bookingToDelete = _bookingUpdate.ReturnBookingWithId(bookingId);
                if (bookingToDelete == null)
                {
                    Console.WriteLine($"No booking found with ID number: {bookingId}.");
                    return;
                }
                bool selectedBookingAsDeleted = AnsiConsole.Confirm(
                    $"Do you want to delete booking: booking Id: {bookingToDelete.Id},  " +
                    $"Customer Id: {bookingToDelete.CustomerId}");

                Console.Clear();
                if (selectedBookingAsDeleted)
                {
                    _bookingDelete.DeleteBooking(bookingId);
                    AnsiConsole.MarkupLine("[bold green]Successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }
                bool addAnother = AnsiConsole.Confirm
                    ("Do you want delete another booking?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}