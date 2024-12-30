using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Helpers;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public static class DisplayAvailableRooms
    {
        public static void PrintAvailableRooms(RoomRead _roomRead,
            UpdateRooms updateRooms, DateTime checkInDate, DateTime checkOutDate)
        {
            Console.Clear();
            updateRooms.UpdateRoomAvailability();

            AnsiConsole.MarkupLine("[bold green]Available rooms:[/]");
            
            var availableRooms = _roomRead.GetAllAvailablebookingRooms
                (checkInDate, checkOutDate)
                .Where(r => r.IsAvailable && !r.IsRoomDeleted)
                .ToList();

            if (availableRooms.Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]No available rooms for the selected dates![/]");
                return;
            }

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
            AnsiConsole.MarkupLine("[bold red](Extra beds) Rooms over 25 " +
                "square meters will automatically get 2 extra beds and under 25 will get 1.[/]");

            AnsiConsole.Write(roomTable);
        }
    }
}
