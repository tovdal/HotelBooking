using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Models;
using HotelBooking.Service.InvoiceService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;

namespace HotelBooking.Controllers.ControllerInvoice
{
    public class InvoiceReadController : IInvoiceReadController
    {
        private readonly InvoiceRead _invoiceRead;
        public InvoiceReadController(InvoiceRead invoiceRead)
        {
            _invoiceRead = invoiceRead;
        }
        public void ShowAllInvoices()
        {
            var invoices = _invoiceRead.GetAllActiveInvoices();

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

                DisplayInvoiceInformation.PrintInvoiceIdAndCustomerID
                    (invoices, "No invoices registered ." +
                    " (Press enter to return to menu)");

                if (ListHelper.CheckIfListIsEmpty(invoices))
                {
                    isSearching = false;
                    return;
                }
                if (!ValidatorBooking.TryGetBookingId(out int invoiceId))
                {
                    continue;
                }

                var invoice = _invoiceRead.GetInvoiceDetails(invoiceId);

                DisplayInvoiceInformation.PrintInvoiceAll
                    (invoice, $"No invoices found with Id: {invoiceId}.");

                ConsoleMessagePrinter.DisplayMessage();
                isSearching = false;
            }
        }
    }
}