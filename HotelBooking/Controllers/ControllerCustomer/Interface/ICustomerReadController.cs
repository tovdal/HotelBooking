namespace HotelBooking.Controllers.ControllerCustomer.Interface
{
    public interface ICustomerReadController
    {
        void ShowAllCustomers();
        void ShowAllActiveCustomers();
        void ShowAllInactiveCustomers();
        void ShowAllDeletedCustomers();
        void ShowACustomersDetailes();
    }
}
