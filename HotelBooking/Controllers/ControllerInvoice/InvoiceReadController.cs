using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Service.InvoiceService;

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
            var invoices = _invoiceRead.GetAllInvoices();
        }
        public void ShowAllNotPaid()
        {
            throw new System.NotImplementedException();
        }
        public void ShowAllPaid()
        {
            throw new System.NotImplementedException();
        }
    }
}