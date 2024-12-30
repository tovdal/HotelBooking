using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Display.DisplayInformation
{
    public class DisplayCustomerInformation
    {
        public static void DisplayCustomerDetails(Customer customer)
        {
            Console.Clear();
            var table = new Table();
            table.AddColumn("[bold]Field[/]");
            table.AddColumn("[bold]Value[/]");
            table.AddRow("First Name", customer.FirstName);
            table.AddRow("Last Name", customer.LastName);
            table.AddRow("Email", customer.Email);
            table.AddRow("Phone Number", customer.PhoneNumber);

            string street = customer.Address?.Street ?? "N/A";
            string city = customer.Address?.City ?? "N/A";
            string postalCode = customer.Address?.PostalCode ?? "N/A";
            string country = customer.Address?.Country ?? "N/A";

            table.AddRow("Street", street);
            table.AddRow("City", city);
            table.AddRow("Postal Code", postalCode);
            table.AddRow("Country", country);

            table.AddRow("Deleted", customer.IsCustomerDeleted ? "Yes" : "No");
            AnsiConsole.Write(table);
        }

        public static void PrintCustomersNamesAndID
            (IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (IsCustomerListEmpty(customers, messageIfEmpty))
            {
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

        public static void PrintCustomersOnlyDetailes
            (IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (IsCustomerListEmpty(customers, messageIfEmpty))
            {
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            table.AddColumn("Street");
            table.AddColumn("City");
            table.AddColumn("Postal Code");
            table.AddColumn("Country");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Address.Street,
                    customer.Address.City,
                    customer.Address.PostalCode,
                    customer.Address.Country
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }

        public static void PrintCustomersAll
            (IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (IsCustomerListEmpty(customers, messageIfEmpty))
            {
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
            table.AddColumn("Postal Code");
            table.AddColumn("Deleted");
            table.AddColumn("Bookings");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Address.Street,
                    customer.Address.City,
                    customer.Address.PostalCode,
                    customer.Address.Country,
                    customer.IsCustomerDeleted ? "Yes" : "No",
                    customer.Bookings?.Count.ToString() ?? "No bookings"
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }
        public static void PrintCustomerShowAll(IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (IsCustomerListEmpty(customers, messageIfEmpty))
            {
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }

        private static bool IsCustomerListEmpty
            (IEnumerable<Customer> customers, string messageIfEmpty)
        {
            if (customers == null || !customers.Any())
            {
                AnsiConsole.MarkupLine($"[red]{messageIfEmpty}[/]");
                return true;
            }
            return false;
        }
    }
}