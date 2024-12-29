using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.CustomerService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Helpers.BookingHelper;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking;

public class BookingCreateController : IBookingCreateController
{
    private readonly BookingCreate _bookingCreate;
    private readonly RoomRead _roomRead;
    private readonly CustomerRead _customerRead;
    private readonly IRoomReadController _roomReadController;
    private readonly UpdateRooms _updateRooms;

    public BookingCreateController(BookingCreate bookingCreate,
        IRoomReadController roomReadController,
        RoomRead roomRead, CustomerRead customerRead,
        UpdateRooms updateRooms)
    {
        _bookingCreate = bookingCreate;
        _roomReadController = roomReadController;
        _roomRead = roomRead;
        _customerRead = customerRead;
        _updateRooms = updateRooms;
    }

    public void CreateBooking()
    {
        bool IsRunning = true;
        while (IsRunning)
        {
            _updateRooms.UpdateRoomAvailability();

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
                AnsiConsole.MarkupLine("[bold red]Check-in date selection canceled.[/]");
                break;
            }

            AnsiConsole.MarkupLine("[bold green]Pick check-out date[/]");
            var selectedCheckOutDate = BookingInputCalenderHelper
                .HandleUserInput(selectedCheckInDate, selectedCheckInDate);
            if (selectedCheckOutDate == DateTime.MinValue)
            {
                AnsiConsole.MarkupLine("[bold red]Check-out date selection canceled.[/]");
                break;
            }

            BookingInputRoomHelper.PromptBookRooms
                (_bookingCreate, _roomRead, selectedCheckInDate, 
                selectedCheckOutDate, _updateRooms);

            var totalBookingPrice = _bookingCreate.TotalPriceOfBooking
                (selectedCheckInDate, selectedCheckOutDate);

            Console.WriteLine($"The total price of all bookings is: {totalBookingPrice:C}");

            DateTime dueDateOnInvoice;
            if (selectedCheckInDate.Date == DateTime.Now.Date)
            {
                dueDateOnInvoice = DateTime.Now.Date.AddHours(23).AddMinutes(59);
            }
            else if ((selectedCheckInDate - DateTime.Now).Days <= 10)
            {
                dueDateOnInvoice = DateTime.Now;
            }
            else
            {
                dueDateOnInvoice = selectedCheckInDate.AddDays(-10);
            }

            var newBooking = new Booking
            {
                CustomerId = customerId,
                CheckInDate = selectedCheckInDate,
                CheckOutDate = selectedCheckOutDate,
                Status = BookingStatus.Active,
                Rooms = _bookingCreate.GetRoomsToBook(),
                Invoice = new Invoice
                {
                    CostAmount = totalBookingPrice,
                    InvoiceDate = DateTime.Now,
                    DueDateOnInvoice = dueDateOnInvoice,
                    IsPaid = false
                }
            };

            DisplayHelper.DisplayBookingDetails(newBooking);

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
