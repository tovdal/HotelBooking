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
                var rooms = _roomRead.GetAllActiveRooms()
                    .ToList();
                DisplayRoomInformation.PrintRoomRoomNumberAndID
                    (rooms, "There are no rooms registered");

                if (!ValidatorRoomId.TryGetRoomId(out int roomId))
                {
                    return;
                }
                var roomToDelete = _roomUpdate.ReturnCustomerWithId(roomId);
                if (roomToDelete == null)
                {
                    AnsiConsole.MarkupLine
                        ("$[bold red]No room found with ID number: {roomId}.[/]");
                    Console.ReadKey();
                    return;
                }
                if (_roomDelete.HasRoomBooking(roomId))
                {
                    AnsiConsole.MarkupLine
                        ("[bold red]The room has a booking, can't be deleted[/]");
                    Console.ReadKey();
                    return;
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