﻿using HotelBooking.Models;
using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper
{
    public static class BookingInputHelper
    {
        public static int PromptBookingId()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>("Enter booking ID: ")
                    .ValidationErrorMessage("[red]Please enter a valid booking ID![/]")
                    .Validate(id => id > 0)
            );
        }

        public static Booking PromptBookingDetails()
        {
            var checkInDate = PromptCheckInDate();
            var checkOutDate = PromptCheckOutDate(checkInDate);

            return new Booking
            {
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                Status = StatusOnBooking.Active,
            };
        }

        public static DateTime PromptCheckInDate()
        {
            AnsiConsole.MarkupLine("[bold green]Pick check-in date[/]");
            return BookingInputCalenderHelper.HandleUserInput(DateTime.Now);
        }

        public static DateTime PromptCheckOutDate(DateTime checkInDate)
        {
            AnsiConsole.MarkupLine("[bold green]Pick check-out date[/]");
            return BookingInputCalenderHelper.HandleUserInput(checkInDate, checkInDate);
        }

        public static bool AreRoomsAvailable(RoomRead roomRead, DateTime checkInDate, DateTime checkOutDate, List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                if (roomRead.IsRoomBooked(room.RoomNumber, checkInDate, checkOutDate))
                {
                    AnsiConsole.MarkupLine($"[bold red]Room {room.RoomNumber} is already booked for the selected dates.[/]");
                    return false;
                }
            }
            return true;
        }
    }
}