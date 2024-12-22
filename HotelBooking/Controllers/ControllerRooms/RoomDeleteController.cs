using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Data;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.PrintInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomDeleteController : IRoomDeleteController
    {
        private readonly RoomRead _roomRead;
        private readonly RoomUpdate _roomUpdate;
        private readonly ApplicationDbContext _dbContext;
        public RoomDeleteController(RoomRead roomRead, RoomUpdate roomUpdate, ApplicationDbContext applicationDbContext)
        {
            _roomRead = roomRead;
            _roomUpdate = roomUpdate;
            _dbContext = applicationDbContext;
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
                // Repeting allot in the code.
                {
                    Console.WriteLine($"No customer found with ID number: {roomId}.");
                    return;
                }

                bool selectedRoomAsDeleted = AnsiConsole.Confirm
                    ($"Do you want to delete customer: {roomToDelete.Id} " +
                    $"{roomToDelete.RoomNumber}");

                Console.Clear();
                if (selectedRoomAsDeleted)
                {
                    roomToDelete.IsRoomDeleted = true;
                    _dbContext.SaveChanges();
                    // Repeting the delete customer
                    AnsiConsole.MarkupLine("[bold green]Successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("Do you want delete another room?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}