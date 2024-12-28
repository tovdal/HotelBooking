using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DsplayInformation;
using HotelBooking.Utilities.Helpers.BookingHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking
{
    public class BookingUpdateController : IBookingUpdateController
    {
        private readonly BookingRead _bookingRead;
        private readonly BookingUpdate _bookingUpdate;
        private readonly RoomRead _roomRead;

        public BookingUpdateController
            (BookingRead bookingRead, BookingUpdate bookingUpdate,
            RoomRead roomRead)
        {
            _bookingRead = bookingRead;
            _bookingUpdate = bookingUpdate;
            _roomRead = roomRead;
        }

        public void UpdateBookingInformation()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var bookings = _bookingRead.GetAllActiveBookings().ToList();
                DisplayBookingInformation.PrintBookingAll
                    (bookings, "There are no active bookings");

                if (!ValidatorBookingId.TryGetBookingId(out int bookingId))
                {
                    continue;
                }

                var bookingToUpdate = _bookingUpdate.ReturnBookingWithId(bookingId);
                if (bookingToUpdate == null)
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]No booking found with ID number: {bookingId}.[/]");
                    continue;
                }

                var updatedBooking = BookingInputHelper.PromptBookingDetails();



                if (!BookingInputHelper.AreRoomsAvailable
                    (_roomRead, updatedBooking.CheckInDate, 
                    updatedBooking.CheckOutDate, bookingToUpdate.Rooms))
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]Update canceled due to room availability conflict.[/]");
                    Console.ReadKey();
                    break;
                }

                bookingToUpdate.CheckInDate = updatedBooking.CheckInDate;
                bookingToUpdate.CheckOutDate = updatedBooking.CheckOutDate;
                bookingToUpdate.Status = updatedBooking.Status;

                _bookingUpdate.SaveChanges();
                AnsiConsole.MarkupLine
                    ("[bold green]Booking successfully updated![/]");

                bool addAnother = AnsiConsole.Confirm
                    ("\nDo you want to update another booking?");
                if (!addAnother)
                {
                    isRunning = false;
                }
                Console.Clear();
            }
        }

        public void TakeBackDeletedBooking()
        {
            throw new NotImplementedException();
        }
    }
}
