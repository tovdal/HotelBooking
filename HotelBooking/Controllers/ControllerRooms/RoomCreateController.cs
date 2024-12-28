using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Helpers.RoomHelper;
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

                var newRoom = RoomInputHelper.PromptRoomDetails(_roomCreate);

                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("Room ID", newRoom.Id.ToString());
                table.AddRow("Room number", newRoom.RoomNumber.ToString());
                table.AddRow("Room size", newRoom.RoomSize.ToString());
                table.AddRow("Type of room", newRoom.TypeOfRoom.ToString());
                table.AddRow("Price per night", newRoom.PricePerNight.ToString());
                table.AddRow("Extra bed available", newRoom.IsExtraBedAvailable.ToString());
                AnsiConsole.Write(table);

                bool confirm = AnsiConsole.Confirm
                    ("\n[bold yellow]Are all details correct?[/]");
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