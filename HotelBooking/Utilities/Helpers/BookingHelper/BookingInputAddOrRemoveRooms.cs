using HotelBooking.Models;
using HotelBooking.Service.RoomService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper;

public static class BookingInputAddOrRemoveRooms
{
    public static void PromptAddOrRemoveRooms(Booking bookingToUpdate, 
        IRoomRead roomRead)
    {
        bool confirmAddRooms = AnsiConsole.Confirm
              ("\n[]Do you want to add or remove rooms?[/]");
        if (confirmAddRooms)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
            .Title("Select an action:")
            .AddChoices(new[] { "Add Room", "Remove Room" }));

            switch (action)
            {
                case "Add Room":
                    var availableRooms = roomRead.GetAllAvailablebookingRooms
                        (bookingToUpdate.CheckInDate, bookingToUpdate.CheckOutDate)
                        .ToList();
                    if (availableRooms.Any())
                    {
                        DisplayRoomInformation.PrintRoomBooking(availableRooms);
                        if (ValidatorRoom.TryGetRoomId(out int roomId))
                        {
                            var roomToAdd = roomRead.GetRoomDetails(roomId)
                                .FirstOrDefault();
                            if (roomToAdd != null)
                            {
                                bookingToUpdate.Rooms.Add(roomToAdd);
                                AnsiConsole.MarkupLine
                                    ("[bold green]Room successfully added![/]");
                            }
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine
                            ("[bold red]No available rooms found for the " +
                            "given dates.[/]");
                    }
                    break;

                case "Remove Room":
                    DisplayRoomInformation.PrintRoomBooking(bookingToUpdate.Rooms);
                    if (ValidatorRoom.TryGetRoomId(out int roomIdToRemove))
                    {
                        var roomToRemove = bookingToUpdate.Rooms
                            .FirstOrDefault(r => r.Id == roomIdToRemove);
                        if (roomToRemove != null)
                        {
                            bookingToUpdate.Rooms.Remove(roomToRemove);
                            AnsiConsole.MarkupLine
                                ("[bold green]Room successfully removed![/]");
                        }
                    }
                    break;
            }
        }
        else
        {
            return;
        }
    }
}