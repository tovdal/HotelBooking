using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Service.BookingService.Interfaces;
using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Service.RoomService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers.BookingHelper;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking;

public class BookingCreateController : IBookingCreateController
{
    private readonly IBookingCreate _bookingCreate;
    private readonly IRoomRead _roomRead;
    private readonly ICustomerRead _customerRead;
    private readonly IRoomUpdate _roomUpdate;

    public BookingCreateController(IBookingCreate bookingCreate,
        IRoomRead roomRead, ICustomerRead customerRead, IRoomUpdate roomUpdate)
    {
        _bookingCreate = bookingCreate;
        _roomRead = roomRead;
        _customerRead = customerRead;
        _roomUpdate = roomUpdate;
    }

    public void CreateBooking()
    {
        bool IsRunning = true;
        while (IsRunning)
        {
            _roomUpdate.UpdateRoomAndBookingAvailability();

            AnsiConsole.MarkupLine("[bold green]1. Register a new booking[/]");

            bool confirmCustomer = AnsiConsole.Confirm
                ("\nIs it a new customer that wishes to make a booking?");
            if (confirmCustomer)
            {
                AnsiConsole.MarkupLine
                    ("[bold green]Customer needs to be registered first![/]");
                Console.ReadKey();
                break;
            }

            var customerId = BookingInputValidateCustomerHelper.ValidateBookingCustomer
                (_customerRead);

            AnsiConsole.MarkupLine("[bold green]Pick check-in date[/]");
            var selectedCheckInDate = BookingInputCalenderHelper.HandleUserInput
                (DateTime.Now);
            if (selectedCheckInDate == DateTime.MinValue)
            {
                break;
            }

            AnsiConsole.MarkupLine("[bold green]Pick check-out date[/]");
            var selectedCheckOutDate = BookingInputCalenderHelper
                .HandleUserInput(selectedCheckInDate, selectedCheckInDate);
            if (selectedCheckOutDate == DateTime.MinValue)
            {
                break;
            }

            BookingInputRoomHelper.PromptBookRooms
                (_bookingCreate, _roomRead, selectedCheckInDate, selectedCheckOutDate, _roomUpdate);

            var totalBookingPrice = _bookingCreate.TotalPriceOfBooking(selectedCheckInDate, selectedCheckOutDate);

            var newBooking = BookingInputHelper.PromptCustomerDetails(customerId,
                selectedCheckInDate, selectedCheckOutDate, _bookingCreate,
                totalBookingPrice);

            DisplayBookingInformation.DisplayBookingDetails(newBooking);

            bool confirm = AnsiConsole.Confirm
                ("\n[bold yellow]Are all details correct?[/]");
            if (confirm)
            {
                _bookingCreate.AddBooking(newBooking);
                AnsiConsole.MarkupLine("[bold green]Booking successfully registered![/]");
                _bookingCreate.ClearRoomsToBook();
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Registration canceled.[/]");
            }

            bool addAnother = AnsiConsole.Confirm("\nDo you want to do another booking?");
            if (!addAnother)
            {
                IsRunning = false;
            }
        }
    }
}