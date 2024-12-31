using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers.RoomHelper;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomCreateController : IRoomCreateController
    {
        private readonly IRoomCreate _roomCreate;
        public RoomCreateController(IRoomCreate roomCreate)
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

                DisplayRoomInformation.DisplayRoomDetails(newRoom);

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