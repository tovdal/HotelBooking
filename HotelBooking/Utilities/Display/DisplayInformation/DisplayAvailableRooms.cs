using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public class DisplayAvailableRooms
    {
        public static void PrintAvailableRooms(RoomRead _roomRead)
        {
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
        }
    }
}
