using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DsplayInformation;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper
{
    public class BookingInputRoomHelper
    {
        public static void PromptBookRooms(BookingCreate _bookingCreate, RoomRead _roomRead)
        {
            bool IsAddingRooms = true;
            while (IsAddingRooms)
            {
                Console.Clear();
                DisplayAvailableRooms.PrintAvailableRooms(_roomRead);

                string roomRoomNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter room number you want to book: ")
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
                if(_bookingCreate.IsRoomBooked(room.RoomNumber))
                {
                    AnsiConsole.MarkupLine("[bold red]Room is already booked![/]");
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

                IsAddingRooms = AnsiConsole.Confirm("\n[bold yellow]Want to add another room?[/]");
            }
        }
    }
}