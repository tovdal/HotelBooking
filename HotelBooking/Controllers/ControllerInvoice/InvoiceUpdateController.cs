using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Models;
using HotelBooking.Service.InvoiceService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;
namespace HotelBooking.Controllers.ControllerInvoice;

public class InvoiceUpdateController : IInvoiceUpdateController
{
    private readonly IInvoiceUpdate _invoiceUpdate;
    private readonly IInvoiceRead _invoiceRead;
    public InvoiceUpdateController(IInvoiceUpdate invoiceUpdate,
        IInvoiceRead invoiceRead)
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
            var invoices = _invoiceRead.GetAllActiveInvoices().ToList();
            DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID
                (invoices, "No invoices that are not paid. " +
                "(Press enter to return to menu)");

            if (ListHelper.CheckIfListIsEmpty(invoices))
            {
                isRunning = false;
                return;
            }
            if (!ValidatorInvoice.TryGetInvoiceId(out int invoiceId))
            {
                isRunning = false;
                return;
            }
            var invoiceToPay = _invoiceUpdate.ReturnInvoiceWithId(invoiceId);
            if (!ValidatorInvoice.ValidateInvoiceForUpdate(invoiceToPay, invoiceId))
            {
                continue;
            }

            var invoice = _invoiceRead.GetInvoiceDetails(invoiceId).FirstOrDefault();

            DisplayInvoiceInformation.PrintInvoiceAll
                (new List<Invoice> { invoice }, 
                $"No invoices found with Id: {invoiceId}.");

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