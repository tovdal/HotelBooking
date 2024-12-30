using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Validators;

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
        // Add Pagination can be found in richards powerpoint 
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
        var rooms = _roomRead.GetAllActiveRooms();
        DisplayRoomInformation.PrintRoomRoomNumberAndID
        (rooms, "There are no rooms.");

        if (!ValidatorRoomId.TryGetRoomId(out int roomId))
        {
            return;
        }

        var room = _roomRead.GetRoomDetails(roomId);
        DisplayRoomInformation.PrintRoomOnlyDetails
            (room, $"No room found with ID number: {roomId}.");
        ConsoleMessagePrinter.DisplayMessage();
    }
}