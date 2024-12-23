using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomCreateController : IRoomCreateController
    {
        private readonly RoomCreate _roomCreate;
        public RoomCreateController(RoomCreate roomCreate)
        {
            _roomCreate = roomCreate;
        }
        public void CreateANewRoom()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                AnsiConsole.MarkupLine("[bold green]1. Create a new room[/]");

                string roomRoomNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter room number: ")
                        .ValidationErrorMessage("[red]Invalid or duplicate room number![/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber)) return false;
                            return !_roomCreate.RoomExists(roomNumber);
                        })
                );

                string roomRoomSize = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter the room size: ")
                        .ValidationErrorMessage("[red]Room size must be a valid positive number![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input) && byte.TryParse(input, out _))
                );

                string roomTypeInput = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter if the room is a Single or Double: ")
                        .ValidationErrorMessage("[red]Please enter 'Single' or 'Double'![/]")
                        .Validate(input => Enum.TryParse<TypeOfRoom>(input, true, out _))
                );
                TypeOfRoom roomTypeOfRoom = Enum.Parse<TypeOfRoom>(roomTypeInput, true);

                string roomPricePerNight = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter the room's price per night: ")
                        .ValidationErrorMessage("[red]Price must be numeric![/]")
                        .Validate(input => decimal.TryParse(input, out _))
                );

                var newRoom = new Room()
                {
                    RoomNumber = int.Parse(roomRoomNumber),
                    RoomSize = byte.Parse(roomRoomSize),
                    TypeOfRoom = roomTypeOfRoom,
                    PricePerNight = decimal.Parse(roomPricePerNight),
                    IsAvailable = true,
                    IsRoomDeleted = false,
                    IsExtraBedAvailable = roomTypeOfRoom == TypeOfRoom.Double
                };

                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("Room ID", newRoom.Id.ToString());
                table.AddRow("Room number", roomRoomNumber);
                table.AddRow("Room size", roomRoomSize);
                table.AddRow("Type of room", roomTypeOfRoom.ToString());
                table.AddRow("Price per night", roomPricePerNight);
                table.AddRow("Extra bed available", newRoom.IsExtraBedAvailable.ToString());
                AnsiConsole.Write(table);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    _roomCreate.AddRoom(newRoom);
                    AnsiConsole.MarkupLine("[bold green]Room successfully registered![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Registration canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to add another room?");
                if (!addAnother)
                {
                    IsRunning = false;
                }
            }
        }
    }
}