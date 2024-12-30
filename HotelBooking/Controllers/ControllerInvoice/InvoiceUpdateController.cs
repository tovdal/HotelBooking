using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Models;
using HotelBooking.Service.InvoiceService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerInvoice
{
    public class InvoiceUpdateController : IInvoiceUpdateController
    {
        private readonly InvoiceUpdate _invoiceUpdate;
        private readonly InvoiceRead _invoiceRead;
        public InvoiceUpdateController(InvoiceUpdate invoiceUpdate,
            InvoiceRead invoiceRead)
        {
            _invoiceUpdate = invoiceUpdate;
            _invoiceRead = invoiceRead;
        }
        public void PayAInvoice()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var invoices = _invoiceRead.GetAllActiveInvoices();
                DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID(invoices);

                if (!ValidatorBookingId.TryGetBookingId(out int invoiceId))
                {
                    continue;
                }

                var invoiceToPay = _invoiceUpdate.ReturnInvoiceWithId(invoiceId);
                if (invoiceToPay == null)
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]No invoice found with Id: {invoiceId}.[/]");
                    continue;
                }

                var invoice = _invoiceRead.GetInvoiceDetails(invoiceId);

                DisplayInvoiceInformation.PrintInvoiceAll
                    (invoice, $"No invoices found with Id: {invoiceId}.");

                bool confirm = AnsiConsole.Confirm
                    ("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    invoiceToPay.Invoice.IsPaid = true;
                    _invoiceUpdate.SaveChanges();
                    AnsiConsole.MarkupLine
                        ($"[green]Invoice with Id: " +
                        $"{invoiceId} has been marked as paid.[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Payment canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm
                    ("\nDo you want to pay another invoice?");
                if (!addAnother)
                {
                    isRunning = false;
                }
                Console.Clear();
            }
        }
    }
}