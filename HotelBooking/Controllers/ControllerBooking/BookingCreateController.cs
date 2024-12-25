using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking
{
    public class BookingCreateController : IBookingCreateController
    {
        private readonly BookingCreate _bookingCreate;
        private readonly RoomRead _roomRead;
        private readonly IRoomReadController _roomReadController;

        public BookingCreateController(BookingCreate bookingCreate, IRoomReadController roomReadController)
        {
            _bookingCreate = bookingCreate;
            _roomReadController = roomReadController;
        }

        public void CreateBooking()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                AnsiConsole.MarkupLine("[bold green]1. Register a new booking[/]");

                bool confirmCustomer = AnsiConsole.Confirm("\nIs it a new customer that wishes to make a booking?");
                if (confirmCustomer)
                {
                    AnsiConsole.MarkupLine("[bold green]Customer needs to be registered first![/]");
                    Console.ReadKey();
                    break;
                }
                AnsiConsole.MarkupLine("[bold green]Type in customer ID[/]");
                ValidatorCustomerId.TryGetCustomerId(out var customerId);

                AnsiConsole.MarkupLine("[bold green]Pick check-in date[/]");
                var selectedCheckInDate = BookingInputCalenderHelper.HandleUserInput(DateTime.Now);
                if (selectedCheckInDate == DateTime.MinValue)
                {
                    AnsiConsole.MarkupLine("[bold red]Check-in date selection canceled.[/]");
                    break;
                }

                AnsiConsole.MarkupLine("[bold green]Pick check-out date[/]");
                var selectedCheckOutDate = BookingInputCalenderHelper.HandleUserInput(selectedCheckInDate, selectedCheckInDate);
                if (selectedCheckOutDate == DateTime.MinValue)
                {
                    AnsiConsole.MarkupLine("[bold red]Check-out date selection canceled.[/]");
                    break;
                }

                AnsiConsole.MarkupLine("[bold green]Available rooms:[/]");
                _roomReadController.ShowAllRooms();

                bool IsAddingRooms = true;
                while (IsAddingRooms)
                {
                    string roomRoomNumber = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter room number you want to book: ")
                            .ValidationErrorMessage("[red]Invalid or room already booked![/]")
                            .Validate(input =>
                            {
                                if (!int.TryParse(input, out int roomNumber)) return false;
                                return !_bookingCreate.IsRoomBooked(roomNumber);
                            })
                    );

                    IsAddingRooms = AnsiConsole.Confirm("\n[bold yellow]Want to add another room?[/]");
                }

                var totalBookingPrice = _bookingCreate.TotalPriceOfBooking();
                Console.WriteLine($"The total price of all bookings is: {totalBookingPrice:C}");

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    //_bookingCreate.AddBooking(newBooking);
                    AnsiConsole.MarkupLine("[bold green]Booking successfully registered![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Registration canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to add another booking?");
                if (!addAnother)
                {
                    IsRunning = false;
                }
            }
        }
    }
}