using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomUpdateController : IRoomUpdateController
    {
        private readonly RoomUpdate _roomUpdate;
        private readonly RoomRead _roomRead;
        private readonly RoomCreate _roomCreate;
        private readonly ApplicationDbContext _dbContext;

        public RoomUpdateController(RoomUpdate roomUpdate, RoomRead roomRead, RoomCreate roomCreate, ApplicationDbContext dbContext)
        {
            _roomUpdate = roomUpdate;
            _roomRead = roomRead;
            _roomCreate = roomCreate;
            _dbContext = dbContext;
        }
        public void UpdateARoomInformation()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                var rooms = _roomRead.GetAllActiveRooms()
                    .ToList();
                DisplayRoomInformation.PrintRoomOnlyDetailes
                    (rooms, "There are no active rooms");
                if (!ValidatorRoomId.TryGetRoomId(out int roomId))
                {
                    continue;
                }

                var roomToUpdate = _roomUpdate.ReturnCustomerWithId(roomId);
                if (roomToUpdate == null)
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]No Room found wiih ID number: {roomId}.[/]");
                    return;
                }

                Console.Clear();

                var room = _roomRead.GetRoomDetails(roomId);
                DisplayRoomInformation.PrintRoomOnlyDetailes
                    (room, $"No Room found with ID number {roomId}");

                //This is repeating CreateANewRoom

                AnsiConsole.MarkupLine("[bold green]1. Update a new room[/]");

                string roomRoomNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update room number: ")
                        .ValidationErrorMessage("[red]Invalid or duplicate room number![/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber)) return false;
                            return !_roomCreate.RoomExists(roomNumber);
                        })
                );

                string roomRoomSize = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update the room size: ")
                        .ValidationErrorMessage("[red]Room size must be a valid positive number![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input) && byte.TryParse(input, out _))
                );

                string roomTypeInput = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update if the room is a Single or Double: ")
                        .ValidationErrorMessage("[red]Please enter 'Single' or 'Double'![/]")
                        .Validate(input => Enum.TryParse<TypeOfRoom>(input, true, out _))
                );
                TypeOfRoom roomTypeOfRoom = Enum.Parse<TypeOfRoom>(roomTypeInput, true);

                string roomPricePerNight = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update the room's price per night: ")
                        .ValidationErrorMessage("[red]Price must be numeric![/]")
                        .Validate(input => decimal.TryParse(input, out _))
                );


                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("Room ID", roomToUpdate.Id.ToString());
                table.AddRow("Room number", roomRoomNumber);
                table.AddRow("Room size", roomRoomSize);
                table.AddRow("Type of room", roomTypeOfRoom.ToString());
                table.AddRow("Price per night", roomPricePerNight);
                table.AddRow("Extra bed available", roomToUpdate.IsExtraBedAvailable.ToString());
                AnsiConsole.Write(table);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    roomToUpdate.RoomNumber = int.Parse(roomRoomNumber);
                    roomToUpdate.RoomSize = byte.Parse(roomRoomSize);
                    roomToUpdate.TypeOfRoom = roomTypeOfRoom;
                    roomToUpdate.PricePerNight = decimal.Parse(roomPricePerNight);
                    roomToUpdate.IsExtraBedAvailable = roomTypeOfRoom == TypeOfRoom.Double;
                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Room successfully registered![/]");
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
                DisplayRoomInformation.PrintRoomOnlyDetailes
                    (deletedRooms, "There are no deleted rooms");

                if (!deletedRooms.Any())
                {
                    isRunning = false;
                    return;
                }

                if (!ValidatorRoomId.TryGetRoomId(out var roomId))
                {
                    continue;
                }

                var roomToUpdate = _roomUpdate.ReturnCustomerWithId(roomId);
                if (roomToUpdate == null || !roomToUpdate.IsRoomDeleted)
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]No deleted room found with ID number: {roomId}.[/]");
                    Console.ReadKey();
                    continue;
                }

                bool restoreRoom = AnsiConsole.Confirm
                    ($"Do you want to restore deleted room: {roomToUpdate.RoomNumber}?");
                if (restoreRoom)
                {
                    roomToUpdate.IsRoomDeleted = false;
                    _dbContext.SaveChanges();
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