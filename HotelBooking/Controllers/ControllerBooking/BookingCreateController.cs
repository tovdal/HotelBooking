using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.CustomerService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking;

public class BookingCreateController : IBookingCreateController
{
    private readonly BookingCreate _bookingCreate;
    private readonly RoomRead _roomRead;
    private readonly CustomerRead _customerRead;
    private readonly IRoomReadController _roomReadController;

    public BookingCreateController(BookingCreate bookingCreate,
        IRoomReadController roomReadController, RoomRead roomRead, CustomerRead customerRead)
    {
        _bookingCreate = bookingCreate;
        _roomReadController = roomReadController;
        _roomRead = roomRead;
        _customerRead = customerRead;
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

            bool customerValid = false;
            int customerId = 0;

            while (!customerValid)
            {
                Console.Clear();

                var registerdCustomers = _customerRead.GetAllActiveCustomers().ToList();
                var customerTable = new Table();
                customerTable.AddColumn("Customer ID");
                customerTable.AddColumn("First Name");
                customerTable.AddColumn("Last Name");

                foreach (var customer in registerdCustomers)
                {
                    customerTable.AddRow(
                        $"{customer.Id}",
                        $"{customer.FirstName}",
                        $"{customer.LastName}");
                }

                if (!registerdCustomers.Any())
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]No active customers found...Any key to try again[/]");
                    return;
                }

                AnsiConsole.Write(customerTable);

                AnsiConsole.MarkupLine("[bold green]Type in customer ID[/]");
                if (ValidatorCustomerId.TryGetCustomerId(out customerId))
                {
                    if (_customerRead.CustomerExists(customerId))
                    {
                        customerValid = true;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine
                            ("[bold red]No customer with that ID! Please try again.[/]");
                        Console.ReadKey();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]Invalid customer ID! Please try again.[/]");
                    Console.ReadKey();
                }
            }

            AnsiConsole.MarkupLine("[bold green]Customer validated![/]");

            AnsiConsole.MarkupLine("[bold green]Pick check-in date[/]");
            var selectedCheckInDate = BookingInputCalenderHelper.HandleUserInput(DateTime.Now);
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

            Console.Clear();
            AnsiConsole.MarkupLine("[bold green]Available rooms:[/]");
            AnsiConsole.MarkupLine("[bold red](Extra beds) Rooms over 25 " +
                "square meters will automatically get 2 extra beds and under 25 will get 1.[/]");

            var availableRooms = _roomRead.GetAllAvailablebookingRooms()
                .Where(r => r.IsAvailable && !r.IsRoomDeleted)
                .ToList();

            var roomTable = new Table();
            roomTable.AddColumn("Room Number");
            roomTable.AddColumn("Room size");
            roomTable.AddColumn("Price per Night");
            roomTable.AddColumn("Extra bed available");

            foreach (var room in availableRooms)
            {
                roomTable.AddRow(
                    room.RoomNumber.ToString(),
                    $"{room.RoomSize}",
                    $"{room.PricePerNight:C}",
                    room.IsExtraBedAvailable ? "Yes" : "No"
                );
            }

            AnsiConsole.Write(roomTable);

            bool IsAddingRooms = true;
            while (IsAddingRooms)
            {
                string roomRoomNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter room number you want to book: ")
                        .ValidationErrorMessage("[red]Invalid or room already booked![/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber)) return false;
                            if (_bookingCreate.IsRoomBooked(roomNumber)) return false;
                            if (_bookingCreate.GetRoomsToBook()
                            .Any(r => r.RoomNumber == roomNumber)) return false;
                            return true;
                        })
                );

                Room room;
                try
                {
                    room = _roomRead.GetRoomByRoomNumber(int.Parse(roomRoomNumber));
                    if (room == null)
                    {
                        throw new InvalidOperationException($"No room found with room number {roomRoomNumber}.");
                    }
                }
                catch (InvalidOperationException)
                {
                    AnsiConsole.MarkupLine("[bold red]No room found with that number[/]");
                    continue;
                }

                if (_roomRead.GetRoomByExtraBed(room.RoomNumber))
                {
                    bool extraBed = AnsiConsole.Confirm("Do you want to add an extra bed?");
                    if (extraBed)
                    {
                        if (room.RoomSize >= 25)
                        {
                            Console.WriteLine("2 beds added");
                        }
                        else
                        {
                            Console.WriteLine("1 bed added");
                        }
                    }
                    _bookingCreate.AddRoomToBooking(roomRoomNumber, extraBed);
                }
                else
                {
                    _bookingCreate.AddRoomToBooking(roomRoomNumber);
                }

                IsAddingRooms = AnsiConsole.Confirm("\n[bold yellow]Want to add another room?[/]");
            }

            var totalBookingPrice = _bookingCreate.TotalPriceOfBooking(selectedCheckInDate, selectedCheckOutDate);
            Console.WriteLine($"The total price of all bookings is: {totalBookingPrice:C}");

            var newBooking = new Booking
            {
                CustomerId = customerId,
                CheckInDate = selectedCheckInDate,
                CheckOutDate = selectedCheckOutDate,
                Status = StatusOnBooking.Active,
                Rooms = _bookingCreate.GetRoomsToBook(),
                Invoice = new Invoice
                {
                    CostAmount = totalBookingPrice,
                    InvoiceDate = DateTime.Now,
                    DueDateOnInvoice = DateTime.Now.AddDays(31),
                    IsPaid = false
                }
            };

            DisplayHelper.DisplayBookingDetails(newBooking);

            bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
            if (confirm)
            {
                _bookingCreate.AddBooking(newBooking);
                AnsiConsole.MarkupLine("[bold green]Booking successfully registered![/]");
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