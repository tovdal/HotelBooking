using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.PrintInformation
{
    public class DisplayRoomInformation
    {
        public static void PrintRoomRoomNumberAndID(IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (rooms == null || !rooms.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Room ID");
            table.AddColumn("Room Number");

            foreach (var room in rooms)
            {
                table.AddRow(
                    room.Id.ToString(),
                    room.RoomNumber.ToString());
            }
            AnsiConsole.Write(table);
        }
        public static void PrintRoomOnlyDetailes(IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (rooms == null || !rooms.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Room ID");
            table.AddColumn("Room Number");
            table.AddColumn("Room Size");
            table.AddColumn("Type of Room");
            table.AddColumn("Price per Night");
            table.AddColumn("Available extra bed");

            foreach (var room in rooms)
            {
                table.AddRow(
                    room.Id.ToString(),
                    room.RoomNumber.ToString(),
                    room.RoomSize.ToString(),
                    room.TypeOfRoom.ToString(),
                    room.PricePerNight.ToString("C"),
                    room.IsExtraBedAvailable ? "Yes" : "No"
                );
            }
            AnsiConsole.Write(table);
        }
        public static void PrintRoomsAll(IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (rooms == null || !rooms.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Room ID");
            table.AddColumn("Room Number");
            table.AddColumn("Room Size");
            table.AddColumn("Type of Room");
            table.AddColumn("Price per Night");
            table.AddColumn("Available extra bed");
            table.AddColumn("Is room Available");


            foreach (var room in rooms)
            {
                table.AddRow(
                    room.Id.ToString(),
                    room.RoomNumber.ToString(),
                    room.RoomSize.ToString(),
                    room.TypeOfRoom.ToString(),
                    room.PricePerNight.ToString("C"),
                    room.IsExtraBedAvailable ? "Yes" : "No",
                    room.IsAvailable ? "Yes" : "No"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }
    }
}