using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers
{
    public class DisplayHelper
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
    }
}