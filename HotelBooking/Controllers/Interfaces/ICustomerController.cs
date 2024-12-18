namespace HotelBooking.Controllers.Interfaces
{
    public interface ICustomerController
    {
        void CreateANewCustomer();
        void ShowAllCustomers();
        void ShowAllActiveCustomers();
        void ShowAllInactiveCustomers();
        void ShowAllDeletedCustomers();
        void ShowACustomersDetailes();
        void UpdateACustomer();
        void DeleteACustomer();
        void TakeBackDeletedCustomer();
    }
}