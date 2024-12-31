using HotelBooking.Models;

namespace HotelBooking.Service.InvoiceService
{
    public interface IInvoiceRead
    {
        IEnumerable<Invoice> GetAllActiveInvoices();
        IEnumerable<Invoice> GetAllPaidInvoices();
        IEnumerable<Invoice> GetAllNotPaidInvoices();
        IEnumerable<Invoice> GetInvoiceDetails(int id);
    }
}