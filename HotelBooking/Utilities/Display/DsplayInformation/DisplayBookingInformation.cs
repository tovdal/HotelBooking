﻿using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DsplayInformation;

public class DisplayBookingInformation
{
    public static void PrintBookingIdAndCustomerID
        (IEnumerable<Booking> bookings)
    {
        {
            if (bookings == null || !bookings.Any())
            {
                AnsiConsole.MarkupLine($"[red]There are no bookings registered[/]");
                return;
            }
            var bookingTable = new Table();
            bookingTable.AddColumn("Booking Id");
            bookingTable.AddColumn("Customer Id");

            foreach (var booking in bookings)
            {
                bookingTable.AddRow(
                    booking.Id.ToString(),
                    booking.CustomerId.ToString()
                    );
                bookingTable.AddEmptyRow();
            }
            AnsiConsole.Write(bookingTable);
        }
    }
    public static void PrintBookingAll
        (IEnumerable<Booking> bookings, string messageIfEmpty)
    {
        if (bookings == null || !bookings.Any())
        {
            AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
            return;
        }
        var bookingTable = new Table();
        bookingTable.AddColumn("Booking Id");
        bookingTable.AddColumn("Customer Id");
        bookingTable.AddColumn("Customer Name");
        bookingTable.AddColumn("Room/Rooms");
        bookingTable.AddColumn("Check in date");
        bookingTable.AddColumn("Check out date");
        bookingTable.AddColumn("Active or Deleted");

        foreach (var booking in bookings)
        {
            var roomNumbers = string
                .Join(", ", booking.Rooms
                .Select(r => r.RoomNumber));

            bookingTable.AddRow(
                booking.Id.ToString(),
                booking.CustomerId.ToString(),
                $"{booking.Customer.FirstName}, {booking.Customer.LastName}",
                roomNumbers,
                booking.CheckInDate.ToString(),
                booking.CheckOutDate.ToString(),
                booking.Status.ToString()
            );
            bookingTable.AddEmptyRow();
        }
        AnsiConsole.Write(bookingTable);
    }
    public static void PrintBookingAndInvoice
        (IEnumerable<Booking> bookings)
    {
        if (bookings == null || !bookings.Any())
        {
            AnsiConsole.MarkupLine($"[red]There are no bookings registered.[/]");
            return;
        }
        var bookingTable = new Table();
        bookingTable.AddColumn("Booking Id");
        bookingTable.AddColumn("Customer Id");
        bookingTable.AddColumn("Check in date");
        bookingTable.AddColumn("Check out date");
        bookingTable.AddColumn("Total Cost");
        bookingTable.AddColumn("Is Paid?");

        foreach (var booking in bookings)
        {
            bookingTable.AddRow(
                booking.Id.ToString(),
                booking.CustomerId.ToString(),
                booking.CheckInDate.ToString(),
                booking.CheckOutDate.ToString(),
                booking.Invoice.CostAmount.ToString("C"),
                booking.Invoice.IsPaid ? "Yes" : "No"

                );
            bookingTable.AddEmptyRow();
        }
        AnsiConsole.Write(bookingTable);
    }
    public static void PrintBookingDeleted
        (IEnumerable<Booking> bookings)
    {
        if (bookings == null || !bookings.Any())
        {
            AnsiConsole.MarkupLine($"[red]There are no deleted bookings.[/]");
            return;
        }
        var bookingTable = new Table();
        bookingTable.AddColumn("Booking Id");
        bookingTable.AddColumn("Customer Id");
        bookingTable.AddColumn("Check in date");
        bookingTable.AddColumn("Check out date");
        bookingTable.AddColumn("Total Cost");
        bookingTable.AddColumn("Is Paid?");
        bookingTable.AddColumn("Is Deleted");

        foreach (var booking in bookings)
        {
            bookingTable.AddRow(
                booking.Id.ToString(),
                booking.CustomerId.ToString(),
                booking.CheckInDate.ToString(),
                booking.CheckOutDate.ToString(),
                booking.Invoice.CostAmount.ToString("C"),
                booking.Invoice.IsPaid ? "Yes" : "No",
                booking.Status.ToString()
                );
            bookingTable.AddEmptyRow();
        }
        AnsiConsole.Write(bookingTable);
    }
}
