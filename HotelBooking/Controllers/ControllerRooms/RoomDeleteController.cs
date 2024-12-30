using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomDeleteController : IRoomDeleteController
    {
        private readonly RoomRead _roomRead;
        private readonly RoomUpdate _roomUpdate;
        private readonly RoomDelete _roomDelete;
        public RoomDeleteController(RoomRead roomRead, RoomUpdate roomUpdate,
            RoomDelete roomDelete)
        {
            _roomRead = roomRead;
            _roomUpdate = roomUpdate;
            _roomDelete = roomDelete;
        }
        public void DeleteRoom()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                var rooms = _roomRead.GetAllActiveRooms()
                    .ToList();
                DisplayRoomInformation.PrintRoomRoomNumberAndID
                    (rooms, "There are no rooms registered");

                if (!ValidatorRoom.TryGetRoomId(out int roomId))
                {
                    continue;
                }

                var roomToDelete = _roomUpdate.ReturnCustomerWithId(roomId);

                if (!ValidatorRoom.ValidateRoomForUpdate(roomToDelete,
                    roomId, _roomDelete))
                {
                    continue;
                }

                bool selectedRoomAsDeleted = AnsiConsole.Confirm
                    ($"Do you want to delete room: {roomToDelete.Id} " +
                    $"{roomToDelete.RoomNumber}");

                Console.Clear();
                if (selectedRoomAsDeleted)
                {
                    roomToDelete.IsRoomDeleted = true;
                    _roomUpdate.SaveChanges();
                    AnsiConsole.MarkupLine
                        ("[bold green]Successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm
                    ("Do you want delete another room?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}