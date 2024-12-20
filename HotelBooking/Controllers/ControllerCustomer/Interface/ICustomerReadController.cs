namespace HotelBooking.Controllers.ControllerCustomer.Interface
{
    public interface ICustomerReadController
    {
        void ShowAllCustomersBookingsInvoices();
        void ShowAllActiveCustomers();
        void ShowAllInactiveCustomers();
        void ShowAllDeletedCustomers();
        void ShowACustomersDetailes();
    }
}
