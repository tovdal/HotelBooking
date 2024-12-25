using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers
{
    public class RoomInputHelper
    {
        public static int PromptRoomNumber(RoomCreate roomCreate)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>("Enter room number: ")
                    .ValidationErrorMessage("[red]Invalid or duplicate room number![/]")
                    .Validate(roomNumber => !roomCreate.RoomExists(roomNumber))
            );
        }

        public static byte PromptRoomSize()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<byte>("Enter the room size: ")
                    .ValidationErrorMessage("[red]Room size must be a valid positive number![/]")
                    .Validate(input => input > 0)
            );
        }

        public static TypeOfRoom PromptRoomType()
        {
            var roomTypeString = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Enter if the room is a [green]Single[/] or [green]Double[/]: ")
                    .AddChoices(Enum.GetNames<TypeOfRoom>())
            );

            return Enum.Parse<TypeOfRoom>(roomTypeString);
        }

        public static decimal PromptRoomPricePerNight()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter the room's price per night: ")
                    .ValidationErrorMessage("[red]Price must be numeric![/]")
                    .Validate(input => input > 0)
            );
        }

        public static Room PromptRoomDetails(RoomCreate roomCreate)
        {
            var roomNumber = PromptRoomNumber(roomCreate);
            var roomSize = PromptRoomSize();
            var roomType = PromptRoomType();
            var pricePerNight = PromptRoomPricePerNight();

            return new Room
            {
                RoomNumber = roomNumber,
                RoomSize = roomSize,
                TypeOfRoom = roomType,
                PricePerNight = pricePerNight,
                IsAvailable = true,
                IsRoomDeleted = false,
                IsExtraBedAvailable = roomType == TypeOfRoom.Double
            };
        }
    }
}