using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public class DisplayInvoiceInformation
    {
        public static void PrintInvoiceIdAndCustomerID
            (IEnumerable<Invoice> invoices)
        {
            if (invoices == null || !invoices.Any())
            {
                AnsiConsole.MarkupLine($"[red]There are no invoices[/]");
                return;
            }
            var invoiceTable = new Table();
            invoiceTable.AddColumn("Invoice Id");
            invoiceTable.AddColumn("Booking Id");
            invoiceTable.AddColumn("Customer Name");
            invoiceTable.AddColumn("Paid or Not Paid");


            foreach (var invoice in invoices)
            {
                invoiceTable.AddRow(
                    invoice.Id.ToString(),
                    invoice.BookingId.ToString(),
                    $"{invoice.Booking.Customer.FirstName}, " +
                    $"{invoice.Booking.Customer.LastName}",
                    invoice.IsPaid ? "Paid" : "Not Paid"
                );
                invoiceTable.AddEmptyRow();
            }
            AnsiConsole.Write(invoiceTable);
        }
        public static void PrintInvoiceAll
        (IEnumerable<Invoice> invoices, string messageIfEmpty)
        {
            if (invoices == null || !invoices.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }
            var invoiceTable = new Table();
            invoiceTable.AddColumn("Invoice Id");
            invoiceTable.AddColumn("Booking Id");
            invoiceTable.AddColumn("Customer Name");
            invoiceTable.AddColumn("Room/Rooms");
            invoiceTable.AddColumn("Check in date");
            invoiceTable.AddColumn("Check out date");
            invoiceTable.AddColumn("Paid or Not Paid");

            foreach (var invoice in invoices)
            {
                var roomNumbers = string
                .Join(", ", invoice.Booking.Rooms
                .Select(r => r.RoomNumber));

                invoiceTable.AddRow(
                    invoice.Id.ToString(),
                    invoice.BookingId.ToString(),
                    $"{invoice.Booking.Customer.FirstName}, " +
                    $"{invoice.Booking.Customer.LastName}",
                    roomNumbers,
                    invoice.Booking.CheckInDate.ToString(),
                    invoice.Booking.CheckOutDate.ToString(),
                    invoice.IsPaid ? "Paid" : "Not Paid"
                );
                invoiceTable.AddEmptyRow();
            }
            AnsiConsole.Write(invoiceTable);
        }
    }
}
