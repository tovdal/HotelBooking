using HotelBooking.Models;
using HotelBooking.Service.RoomService.Interfaces;
using Spectre.Console;

namespace HotelBooking.Utilities.Validators
{
    public static class ValidatorRoom
    {
        public static bool TryGetRoomId(out int roomId)
        {
            Console.Write("Enter the ID of the Room: ");
            var stringID = Console.ReadLine();

            if (!int.TryParse(stringID, out roomId))
            {
                AnsiConsole.MarkupLine
                    ("[bold red]Please enter a valid number ID[/]");
                Console.ReadKey();
                return false;
            }

            return true;
        }
        public static bool ValidateRoomForUpdate(Room roomToUpdate, 
            int roomId, IRoomDelete roomDelete)
        {
            if (roomToUpdate == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No Room found with ID number: {roomId}.[/]");
                Console.ReadKey();
                return false;
            }
            if (roomDelete.HasRoomBooking(roomId))
            {
                AnsiConsole.MarkupLine
                    ("[bold red]The room has a booking, can't be changed[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool ValidateDeletedRoomForRestore(Room roomToUpdate, int roomId)
        {
            if (roomToUpdate == null || !roomToUpdate.IsRoomDeleted)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No deleted room found with ID number: {roomId}.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool ValidateDeletedRooms(List<Room> deletedRooms)
        {
            if (!deletedRooms.Any())
            {
                AnsiConsole.MarkupLine("[bold red].[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool IsRoomDeleted(Room room, int roomId)
        {
            if (room.IsRoomDeleted)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]Room with ID number: {roomId} is deleted.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
