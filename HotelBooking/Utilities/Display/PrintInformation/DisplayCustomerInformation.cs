using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.PrintInformation
{
    public class DisplayCustomerInformation
    {
        public static void PrintCustomersNamesAndID(IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (customers == null || !customers.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }
        public static void PrintCustomersOnlyDetailes(IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (customers == null || !customers.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            table.AddColumn("Street");
            table.AddColumn("City");
            table.AddColumn("Country");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Address?.Street ?? "N/A",
                    customer.Address?.City ?? "N/A",
                    customer.Address?.Country ?? "N/A"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }
        public static void PrintCustomersAll(IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (customers == null || !customers.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            table.AddColumn("Street");
            table.AddColumn("City");
            table.AddColumn("Country");
            table.AddColumn("Deleted");
            table.AddColumn("Bookings");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Address?.Street ?? "N/A",
                    customer.Address?.City ?? "N/A",
                    customer.Address?.Country ?? "N/A",
                    customer.IsCustomerDeleted ? "Yes" : "No",
                    customer.Bookings?.Count.ToString() ?? "0"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }
    }
}