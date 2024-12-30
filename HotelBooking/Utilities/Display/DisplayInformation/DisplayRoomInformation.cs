using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public class DisplayRoomInformation
    {
        public static void DisplayRoomDetails(Room newRoom)
        {
            Console.Clear();
            var table = new Table();
            table.AddColumn("[bold]Field[/]");
            table.AddColumn("[bold]Value[/]");
            table.AddRow("Room number", newRoom.RoomNumber.ToString());
            table.AddRow("Room size", newRoom.RoomSize.ToString());
            table.AddRow("Type of room", newRoom.TypeOfRoom.ToString());
            table.AddRow("Price per night", newRoom.PricePerNight.ToString());
            table.AddRow("Extra bed available", newRoom.IsExtraBedAvailable.ToString());
            AnsiConsole.Write(table);
        }

        public static void PrintRoomRoomNumberAndID
            (IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (IsRoomListEmpty(rooms, messageIfEmpty))
            {
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

        public static void PrintRoomOnlyDetails
            (IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (IsRoomListEmpty(rooms, messageIfEmpty))
            {
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

        public static void ShowAllRoomDetails
            (IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (IsRoomListEmpty(rooms, messageIfEmpty))
            {
                return;
            }

            var table = new Table();
            table.AddColumn("Room ID");
            table.AddColumn("Room number");
            table.AddColumn("Room size");
            table.AddColumn("Type of room");
            table.AddColumn("Price per night");
            table.AddColumn("Is room bookable?");
            table.AddColumn("Extra beds?");
            table.AddColumns("Is 'deleted'");

            foreach (var room in rooms)
            {
                table.AddRow(
                    room.Id.ToString(),
                    room.RoomNumber.ToString(),
                    room.RoomSize.ToString(),
                    room.TypeOfRoom.ToString(),
                    room.PricePerNight.ToString("C"),
                    room.IsAvailable ? "Yes" : "No",
                    room.IsExtraBedAvailable ? "Yes" : "No",
                    room.IsRoomDeleted ? "Yes" : "No"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }

        public static void PrintRoomBooking
            (List<Room> availableRooms)
        {
            if (availableRooms.Count == 0)
            {
                AnsiConsole.MarkupLine
                    ("[bold red]No available rooms for the selected dates![/]");
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
            

            AnsiConsole.Write(roomTable);
        }

        private static bool IsRoomListEmpty
           (IEnumerable<Room> rooms, string messageIfEmpty)
        {
            if (rooms == null || !rooms.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return true;
            }
            return false;
        }
    }
}