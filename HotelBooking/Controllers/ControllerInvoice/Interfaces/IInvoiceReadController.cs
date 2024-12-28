namespace HotelBooking.Controllers.ControllerInvoice.Interfaces
{
    public interface IInvoiceReadController
    {
        void ShowAllInvoices();
        void ShowAllNotPaid();
        void ShowAllPaid();
    }
}