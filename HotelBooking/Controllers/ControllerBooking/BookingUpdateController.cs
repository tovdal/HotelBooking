using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Models;
using HotelBooking.Service.BookingService.Interfaces;
using HotelBooking.Service.RoomService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Helpers.BookingHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking;

public class BookingUpdateController : IBookingUpdateController
{
    private readonly IBookingRead _bookingRead;
    private readonly IBookingUpdate _bookingUpdate;
    private readonly IRoomRead _roomRead;

    public BookingUpdateController
        (IBookingRead bookingRead, IBookingUpdate bookingUpdate,
        IRoomRead roomRead)
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
                (bookings, "There are no active bookings. " +
                "(Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(bookings))
            {
                isRunning = false;
                return;
            }
            if (!ValidatorBooking.TryGetBookingId(out int bookingId))
            {
                isRunning = false;
                continue;
            }

            var bookingToUpdate = _bookingUpdate.ReturnBookingWithId(bookingId);
            if (!ValidatorBooking.ValidateBookingForUpdate(bookingToUpdate, bookingId))
            {
                continue;
            }
            if (!ValidatorBooking.IsBookingDeleted(bookingToUpdate, bookingId))
            {
                isRunning = false;
                return;
            }

            var updatedBooking = BookingInputHelper.PromptBookingDetails();

            if (!ValidatorBooking.AreRoomsAvailable(_roomRead,
                updatedBooking.CheckInDate, updatedBooking.CheckOutDate,
                bookingToUpdate.Rooms))
            {
                AnsiConsole.MarkupLine
                   ("[bold red]Update canceled due to room availability conflict.[/]");
                break;
            }

            DisplayBookingInformation.DisplayBookingDetailsOnly(updatedBooking);
            bool confirm = AnsiConsole.Confirm
                   ("\n[bold yellow]Are all details correct?[/]");
            if (confirm)
            {
                bookingToUpdate.CheckInDate = updatedBooking.CheckInDate;
                bookingToUpdate.CheckOutDate = updatedBooking.CheckOutDate;
                bookingToUpdate.Status = updatedBooking.Status;

                _bookingUpdate.SaveChanges();
                AnsiConsole.MarkupLine("[bold green]Booking successfully updated![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Update canceled.[/]");
            }

            bool addAnother = AnsiConsole.Confirm
                ("\nDo you want to update another booking?");
            if (!addAnother)
            {
                isRunning = false;
            }
            Console.Clear();
        }
    }
}