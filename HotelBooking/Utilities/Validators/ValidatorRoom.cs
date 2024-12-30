using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Validators
{
    public static class ValidatorRoom
    {
        public static bool TryGetRoomId(out int roomId)
        {
            Console.WriteLine("Enter the ID of the room: ");
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
            int roomId, RoomDelete roomDelete)
        {
            if (roomToUpdate == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No Room found with ID number: {roomId}.[/]");
                return false;
            }
            if (roomDelete.HasRoomBooking(roomId))
            {
                AnsiConsole.MarkupLine
                    ("[bold red]The room has a booking, can't be updated[/]");
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
                AnsiConsole.MarkupLine("[bold red]There are no deleted rooms.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
