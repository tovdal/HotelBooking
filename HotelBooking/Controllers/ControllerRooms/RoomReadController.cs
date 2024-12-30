using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Display.DisplayInformation;
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
        // needs revisiting. takes deleted customers. It should not do that. or?
        var rooms = _roomRead.GetAllRoomsInDb().ToList();

        if (rooms == null || !rooms.Any())
        {
            AnsiConsole.MarkupLine("[red]There are no rooms registered.[/]");
            Console.ReadLine();
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
        ConsoleMessagePrinter.DisplayMessage();
        // Add Pagination can be found in richards powerpoint 
    }

    public void ShowAllDeletedRooms()
    {
        var rooms = _roomRead.GetAllDeletedRoomsInDatabase();
        DisplayRoomInformation.PrintRoomOnlyDetailes
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
        DisplayRoomInformation.PrintRoomsAll
            (room, $"No room found with ID number: {roomId}.");
        ConsoleMessagePrinter.DisplayMessage();
    }
}