namespace HotelBooking.Controllers.Interfaces
{
    public interface IInvoiceController
    {
        void ShowAllInvoices();
        void ShowAllNotPaidInvoices();
        void ShowAllPaidInvoices();
        void ShowInvoiceDetails();
        void PayAInvoice();
    }
}