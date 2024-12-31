using HotelBooking.Service.BookingService;
using HotelBooking.Service.BookingService.Interfaces;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper
{
    public class BookingInputRoomHelper
    {
        public static void PromptBookRooms(IBookingCreate _bookingCreate,
            RoomRead _roomRead, DateTime checkInDate,
            DateTime checkOutDate, RoomUpdate _roomUpdate)
        {
            bool IsAddingRooms = true;
            while (IsAddingRooms)
            {
                Console.Clear();
                DisplayRoomAvailability.PrintAvailableRooms
                    (_roomRead, _roomUpdate, checkInDate, checkOutDate);

                string roomRoomNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>($"Enter room number you want to book for date:" +
                    $" {checkInDate:yyyy-MM-dd} - {checkOutDate:yyyy-MM-dd} : ")
                        .ValidationErrorMessage("[red]Invalid room![/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber)) return false;
                            if (_bookingCreate.GetRoomsToBook()
                            .Any(r => r.RoomNumber == roomNumber)) return false;
                            return true;
                        })
                );

                var room = _roomRead.GetRoomByRoomNumber(int.Parse(roomRoomNumber));
                if (room == null)
                {
                    AnsiConsole.MarkupLine("[bold red]No room found with that number[/]");
                    Console.ReadKey();
                    continue;
                }
                if (_roomRead.IsRoomDeleted(room.RoomNumber))
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]Room is deleted, pick another![/]");
                    Console.ReadKey();
                    continue;
                }

                if (_roomRead.IsRoomBooked(room.RoomNumber, checkInDate, checkOutDate))
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]Room is already booked for the selected dates![/]");
                    Console.ReadKey();
                    continue;
                }

                if (_roomRead.GetRoomByExtraBed(room.RoomNumber))
                {
                    bool extraBed = AnsiConsole.Confirm("Do you want to add an extra bed?");
                    _bookingCreate.AddRoomToBooking(roomRoomNumber, extraBed);
                }
                else
                {
                    _bookingCreate.AddRoomToBooking(roomRoomNumber);
                }

                IsAddingRooms = AnsiConsole.Confirm
                    ("\n[bold yellow]Want to add another room?[/]");
            }
        }
    }
}