using HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Helpers.RoomHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder;

public class RoomUpdateRoom : IRoomUpdateRoom
{
    private readonly IRoomUpdate _roomUpdate;
    private readonly IRoomRead _roomRead;
    private readonly IRoomCreate _roomCreate;
    private readonly IRoomDelete _roomDelete;

    public RoomUpdateRoom(IRoomUpdate roomUpdate,
        IRoomRead roomRead, IRoomCreate roomCreate, IRoomDelete roomDelete)
    {
        _roomUpdate = roomUpdate;
        _roomRead = roomRead;
        _roomCreate = roomCreate;
        _roomDelete = roomDelete;
    }
    public void UpdateARoomInformation()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();

            var rooms = _roomRead.GetAllActiveRooms()
                .ToList();
            DisplayRoomInformation.PrintRoomOnlyDetails
                (rooms, "There are no active rooms. (Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(rooms))
            {
                isRunning = false;
                return;
            }
            if (!ValidatorRoom.TryGetRoomId(out int roomId))
            {
                isRunning = false;
                continue;
            }

            var roomToUpdate = _roomUpdate.ReturnCustomerWithId(roomId);

            if (!ValidatorRoom.ValidateRoomForUpdate(roomToUpdate, roomId, _roomDelete))
            {
                continue;
            }

            var room = _roomRead.GetRoomDetails(roomId);

            DisplayRoomInformation.PrintRoomOnlyDetails
                (room, $"No Room found with ID number {roomId}");

            var updatedRoom = RoomInputHelper.PromptRoomDetails(_roomCreate);

            DisplayRoomInformation.DisplayRoomDetails(updatedRoom);


            bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
            if (confirm)
            {
                roomToUpdate.RoomNumber = updatedRoom.RoomNumber;
                roomToUpdate.RoomSize = updatedRoom.RoomSize;
                roomToUpdate.TypeOfRoom = updatedRoom.TypeOfRoom;
                roomToUpdate.PricePerNight = updatedRoom.PricePerNight;
                roomToUpdate.IsExtraBedAvailable = updatedRoom.TypeOfRoom == TypeOfRoom.Double;
                _roomUpdate.SaveChanges();
                AnsiConsole.MarkupLine
                    ("[bold green]Room successfully registered![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Update canceled.[/]");
            }

            bool addAnother = AnsiConsole.Confirm("\nDo you want to change another room?");
            if (!addAnother)
            {
                isRunning = false;
            }
            Console.Clear();
        }
    }
}