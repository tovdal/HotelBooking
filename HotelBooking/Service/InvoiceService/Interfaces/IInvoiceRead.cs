using HotelBooking.Models;

namespace HotelBooking.Service.InvoiceService.Interfaces
{
    public interface IInvoiceRead
    {
        IEnumerable<Invoice> GetAllActiveInvoices();
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Invoice> GetAllPaidInvoices();
        IEnumerable<Invoice> GetAllNotPaidInvoices();
        IEnumerable<Invoice> GetInvoiceDetails(int id);
    }
}