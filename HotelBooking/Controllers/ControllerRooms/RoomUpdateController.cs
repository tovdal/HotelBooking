using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers.RoomHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomUpdateController : IRoomUpdateController
    {
        private readonly RoomUpdate _roomUpdate;
        private readonly RoomRead _roomRead;
        private readonly RoomCreate _roomCreate;
        private readonly RoomDelete _roomDelete;

        public RoomUpdateController(RoomUpdate roomUpdate,
            RoomRead roomRead, RoomCreate roomCreate, RoomDelete roomDelete)
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
                    (rooms, "There are no active rooms");

                if (!ValidatorRoom.TryGetRoomId(out int roomId))
                {
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

        public void GetBackDeletedRoom()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var deletedRooms = _roomRead.GetAllDeletedRoomsInDatabase().ToList();
                DisplayRoomInformation.PrintRoomOnlyDetails
                    (deletedRooms, "There are no deleted rooms");

                if (!ValidatorRoom.ValidateDeletedRooms(deletedRooms))
                {
                    isRunning = false;
                    return;
                }

                if (!ValidatorRoomId.TryGetRoomId(out var roomId))
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
}