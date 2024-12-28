namespace HotelBooking.Controllers.Interfaces
{
    public interface IInvoiceController
    {
        void ShowAllInvoices();
        void ShowAInvoiceDetails();
        void UpdateAInvoice();
        void PayAInvoice();
    }
}
