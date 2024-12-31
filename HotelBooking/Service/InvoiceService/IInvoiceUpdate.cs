using HotelBooking.Models;

namespace HotelBooking.Service.InvoiceService
{
    public interface IInvoiceUpdate
    {
        Invoice ReturnInvoiceWithId(int id);
        void SaveChanges();
    }
}