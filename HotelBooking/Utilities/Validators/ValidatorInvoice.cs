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
    }
}