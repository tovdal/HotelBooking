using HotelBooking.Models;

namespace HotelBooking.Service.InvoiceService.Interfaces
{
    public interface IInvoiceUpdate
    {
        Invoice ReturnInvoiceWithId(int id);
        void SaveChanges();
    }
}