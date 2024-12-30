using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public static class DisplayRoomAvailability
    {
        public static void PrintAvailableRooms(RoomRead _roomRead,
            RoomUpdate _roomUpdate, DateTime checkInDate, DateTime checkOutDate)
        {
            Console.Clear();
            _roomUpdate.UpdateRoomAndBookingAvailability();

            AnsiConsole.MarkupLine("[bold green]Available rooms:[/]");

            var availableRooms = _roomRead.GetAllAvailablebookingRooms
                (checkInDate, checkOutDate)
                .Where(r => r.IsAvailable && !r.IsRoomDeleted)
                .ToList();

            DisplayRoomInformation.PrintRoomBooking(availableRooms);
            AnsiConsole.MarkupLine("[bold red](Extra beds) Rooms over 25 square " +
                "meters will automatically get 2 extra beds and under 25 will get 1.[/]");
        }
    }
}
