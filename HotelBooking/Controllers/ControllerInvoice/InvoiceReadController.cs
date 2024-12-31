using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Models;
using HotelBooking.Service.InvoiceService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerInvoice
{
    public class InvoiceReadController : IInvoiceReadController
    {
        private readonly IInvoiceRead _invoiceRead;
        public InvoiceReadController(IInvoiceRead invoiceRead)
        {
            _invoiceRead = invoiceRead;
        }
        public void ShowAllInvoices()
        {
            var invoices = _invoiceRead.GetAllInvoices();

            DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID
                (invoices, "There are no invoices.");

            ConsoleMessagePrinter.DisplayMessage();
        }
        public void ShowAllNotPaid()
        {
            var invoices = _invoiceRead.GetAllNotPaidInvoices();

            DisplayInvoiceInformation.PrintInvoiceAll(invoices,
                "There are no invoices");

            ConsoleMessagePrinter.DisplayMessage();

        }
        public void ShowAllPaid()
        {
            var invoices = _invoiceRead.GetAllPaidInvoices();

            DisplayInvoiceInformation.PrintInvoiceAll
                (invoices, "There are no paid invoices");

            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAInvoiceDetails()
        {
            bool isSearching = true;
            while (isSearching)
            {
                Console.Clear();
                var invoices = _invoiceRead.GetAllActiveInvoices().ToList();

                AnsiConsole.MarkupLine($"[green]Show a invoices details[/]");

                DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID
                    (invoices, "No invoices registered." +
                    " (Press enter to return to menu)");

                if (ListHelper.CheckIfListIsEmpty(invoices))
                {
                    isSearching = false;
                    return;
                }

                if (!ValidatorInvoice.TryGetInvoiceId(out int invoiceId))
                {
                    continue;
                }

                var invoice = invoices.FirstOrDefault(i => i.Id == invoiceId);
                if (invoice == null)
                {
                    AnsiConsole.MarkupLine($"[bold red]No invoice found with ID number: {invoiceId}.[/]");
                    Console.ReadKey();
                    continue;
                }

                if (!ValidatorInvoice.IsInvoiceDeleted(invoice, invoiceId))
                {
                    isSearching = false;
                    return;
                }

                var invoiceDetails = _invoiceRead.GetInvoiceDetails(invoiceId);

                DisplayInvoiceInformation.PrintInvoiceAll(invoiceDetails, $"No invoices found with Id: {invoiceId}.");

                ConsoleMessagePrinter.DisplayMessage();
                isSearching = false;
            }
        }
    }
}