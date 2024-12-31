using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms;

public class RoomReadController : IRoomReadController
{
    private readonly IRoomRead _roomRead;
    public RoomReadController(IRoomRead roomRead)
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
            Console.Clear();
            var rooms = _roomRead.GetAllActiveRooms().ToList();
            DisplayRoomInformation.PrintRoomRoomNumberAndID
            (rooms, "There are no rooms. . (Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(rooms))
            {
                isSearching = false;
                return;
            }
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