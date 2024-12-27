using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.RoomService;
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
                        throw new InvalidOperationException
                            ($"No room found with room number {roomRoomNumber}.");
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

                IsAddingRooms = AnsiConsole.Confirm
                    ("\n[bold yellow]Want to add another room?[/]");
            }
        }
    }
}