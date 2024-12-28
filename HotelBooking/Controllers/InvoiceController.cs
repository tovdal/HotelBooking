using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers
{
    public class InvoiceController : IInvoiceController
    {
        private readonly IInvoiceReadController _invoiceReadController;
        private readonly IInvoiceUpdateController _invoiceUpdateController;

        public InvoiceController(IInvoiceReadController invoiceReadController,
            IInvoiceUpdateController invoiceUpdateController)
        {
            _invoiceReadController = invoiceReadController;
            _invoiceUpdateController = invoiceUpdateController;
        }

        public void ShowAllInvoices()
        {
            _invoiceReadController.ShowAllInvoices();
        }

        public void ShowInvoiceDetails()
        {
            _invoiceReadController.ShowAInvoiceDetails();
        }

        public void ShowAllNotPaidInvoices()
        {
            _invoiceReadController.ShowAllNotPaid();
        }

        public void ShowAllPaidInvoices()
        {
            _invoiceReadController.ShowAllPaid();
        }
        public void PayAInvoice()
        {
            _invoiceUpdateController.PayAInvoice();
        }
    }
}