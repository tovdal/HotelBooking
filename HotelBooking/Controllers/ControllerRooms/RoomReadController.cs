using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms;

public class RoomReadController : IRoomReadController
{
    private readonly RoomRead _roomRead;
    public RoomReadController(RoomRead roomRead)
    {
        _roomRead = roomRead;
    }
    public void ShowAllRooms()
    {
        var rooms = _roomRead.GetAllRoomsInDb().ToList();

        DisplayRoomInformation.ShowAllRoomDetails
            (rooms, "There are no rooms registered.");

        ConsoleMessagePrinter.DisplayMessage();
    }

    public void ShowAllDeletedRooms()
    {
        var rooms = _roomRead.GetAllDeletedRoomsInDatabase();
        DisplayRoomInformation.PrintRoomOnlyDetails
            (rooms, "There are no deleted rooms.");
        ConsoleMessagePrinter.DisplayMessage();
    }

    public void ShowARoomDetailes()
    {
        bool isSearching = true;
        while (isSearching)
        {
            var rooms = _roomRead.GetAllActiveRooms();
            DisplayRoomInformation.PrintRoomRoomNumberAndID
            (rooms, "There are no rooms.");

            if (!ValidatorRoom.TryGetRoomId(out int roomId))
            {
                continue;
            }
            var room = _roomRead.GetRoomDetails(roomId).FirstOrDefault();
            if (room == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No room found with ID number: {roomId}.[/]");
                Console.ReadKey();
                continue;
            }
            if (!ValidatorRoom.IsRoomDeleted(room, roomId))
            {
                isSearching = false;
                return;
            }

            DisplayRoomInformation.PrintRoomOnlyDetails
                (new List<Room> { room }, 
                $"No room found with ID number: {roomId}.");
            ConsoleMessagePrinter.DisplayMessage();
            isSearching = false;
        }
    }
}