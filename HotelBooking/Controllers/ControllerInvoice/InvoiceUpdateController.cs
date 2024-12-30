using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Service.InvoiceService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;
namespace HotelBooking.Controllers.ControllerInvoice;

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
            DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID
                (invoices, "No invoices registered. (Press enter to return to menu)");

            if (!ValidatorInvoice.TryGetInvoiceId(out int invoiceId))
            {
                isRunning = false;
                continue;
            }

            var invoiceToPay = _invoiceUpdate.ReturnInvoiceWithId(invoiceId);
            if (!ValidatorInvoice.ValidateInvoiceForUpdate(invoiceToPay, invoiceId))
            {
                continue;
            }

            var invoice = _invoiceRead.GetInvoiceDetails(invoiceId);

            DisplayInvoiceInformation.PrintInvoiceAll
                (invoice, $"No invoices found with Id: {invoiceId}.");

            bool confirm = AnsiConsole.Confirm
                ("\n[bold yellow]Are all details correct?[/]");
            if (confirm)
            {
                invoiceToPay.IsPaid = true;
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