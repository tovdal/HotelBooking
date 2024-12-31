using HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder;

public class RoomUpdateRestore : IRoomUpdateRestore
{
    private readonly RoomUpdate _roomUpdate;
    private readonly RoomRead _roomRead;

    public RoomUpdateRestore(RoomUpdate roomUpdate,RoomRead roomRead)
    {
        _roomUpdate = roomUpdate;
        _roomRead = roomRead;
    }
    public void GetBackDeletedRoom()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            var deletedRooms = _roomRead.GetAllDeletedRoomsInDatabase().ToList();
            DisplayRoomInformation.PrintRoomOnlyDetails
                (deletedRooms, "There are no deleted rooms. (Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(deletedRooms))
            {
                isRunning = false;
                return;
            }
            if (!ValidatorRoom.ValidateDeletedRooms(deletedRooms))
            {
                isRunning = false;
                continue;
            }

            if (!ValidatorRoom.TryGetRoomId(out var roomId))
            {
                continue;
            }

            var roomToUpdate = _roomUpdate.ReturnCustomerWithId(roomId);
            if (!ValidatorRoom.ValidateDeletedRoomForRestore(roomToUpdate, roomId))
            {
                continue;
            }

            bool restoreRoom = AnsiConsole.Confirm
                ($"Do you want to restore deleted room: {roomToUpdate.RoomNumber}?");
            if (restoreRoom)
            {
                roomToUpdate.IsRoomDeleted = false;
                _roomUpdate.SaveChanges();
                AnsiConsole.MarkupLine("[bold green]Successfully restored![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Restore canceled.[/]");
            }

            bool restoreAnother = AnsiConsole.Confirm
                ("Do you want to restore another deleted room?");
            if (!restoreAnother)
            {
                isRunning = false;
            }
            Console.Clear();
        }
    }
}