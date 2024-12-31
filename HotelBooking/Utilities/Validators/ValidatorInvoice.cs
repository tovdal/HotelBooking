using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Validators
{
    public class ValidatorInvoice
    {

        public static bool TryGetInvoiceId(out int invoiceId)
        {
            Console.Write("Enter the ID of the Invoice: ");
            var stringInvoiceID = Console.ReadLine();

            if (!int.TryParse(stringInvoiceID, out invoiceId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return false;
            }

            return true;
        }
        public static bool ValidateInvoiceForUpdate(Invoice invoiceToPay,
               int invoiceId)
        {
            if (invoiceToPay == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No invoice found with Id: {invoiceId}.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public static bool IsInvoiceDeleted(Invoice invoice, int invoiceId)
        {
            if (invoice.Booking == null || invoice.Booking.Customer == null)
            {
                AnsiConsole.MarkupLine($"[bold red]No booking or customer found for invoice ID: {invoiceId}.[/]");
                Console.ReadKey();
                return false;
            }

            if (invoice.Booking.Customer.IsCustomerDeleted)
            {
                AnsiConsole.MarkupLine($"[bold red]Customer with ID number: {invoice.Booking.Customer.Id} is deleted.[/]");
                Console.ReadKey();
                return false;
            }

            return true;
        }
    }
}