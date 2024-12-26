using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
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

        public BookingCreateController(BookingCreate bookingCreate, IRoomReadController roomReadController, RoomRead roomRead)
        {
            _bookingCreate = bookingCreate;
            _roomReadController = roomReadController;
            _roomRead = roomRead;
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
                    AnsiConsole.MarkupLine("[bold green]Type in customer ID[/]");
                    if (ValidatorCustomerId.TryGetCustomerId(out customerId))
                    {
                        customerValid = true;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]No customer with that ID! Please try again.[/]");
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
                var selectedCheckOutDate = BookingInputCalenderHelper.HandleUserInput(selectedCheckInDate, selectedCheckInDate);
                if (selectedCheckOutDate == DateTime.MinValue)
                {
                    AnsiConsole.MarkupLine("[bold red]Check-out date selection canceled.[/]");
                    break;
                }

                Console.Clear();
                AnsiConsole.MarkupLine("[bold green]Available rooms:[/]");
                AnsiConsole.MarkupLine("[bold red](Extra beds) Rooms over 25 square meters will automatically get 2 extra beds and under 25 will get 1.[/]");

                var availableRooms = _roomRead.GetAllAvailablebookingRooms()
                    .Where(r => r.IsAvailable && !r.IsRoomDeleted)
                    .ToList();

                var table = new Table();
                table.AddColumn("Room Number");
                table.AddColumn("Room size");
                table.AddColumn("Price per Night");
                table.AddColumn("Extra bed available");

                foreach (var room in availableRooms)
                {
                    table.AddRow(room.RoomNumber.ToString(),
                        $"{room.RoomSize}",
                        $"{room.PricePerNight:C}",
                        room.IsExtraBedAvailable.ToString());
                }

                AnsiConsole.Write(table);

                bool IsAddingRooms = true;
                while (IsAddingRooms)
                {
                    string roomRoomNumber = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter room number you want to book: ")
                            .ValidationErrorMessage("[red]Invalid or room already booked![/]")
                            .Validate(input =>
                            {
                                if (!int.TryParse(input, out int roomNumber)) return false;
                                return !_bookingCreate.IsRoomBooked(roomNumber)
                                && !_bookingCreate.GetRoomsToBook()
                                .Any(r => r.RoomNumber == roomNumber);
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
                    catch (InvalidOperationException ex)
                    {
                        AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
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

                var totalBookingPrice = _bookingCreate.TotalPriceOfBooking();
                Console.WriteLine($"The total price of all bookings is: {totalBookingPrice:C}");

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    var newBooking = new Booking
                    {
                        CustomerId = customerId,
                        CheckInDate = selectedCheckInDate,
                        CheckOutDate = selectedCheckOutDate,
                        TotalCostOfTheBooking = totalBookingPrice,
                        Status = StatusOnBooking.Active,
                        Rooms = _bookingCreate.GetRoomsToBook(),
                        Invoice = new Invoice
                        {
                            CostAmount = totalBookingPrice,
                            InvoiceDate = DateTime.Now,
                            DueDateOnInvoice = selectedCheckOutDate,
                            IsPaid = false
                        }
                    };
                    _bookingCreate.AddBooking(newBooking);
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