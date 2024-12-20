namespace HotelBooking.Controllers.Interfaces
{
    public interface ICustomerController
    {
        void CreateCustomer();
        void ReadAllCustomers();
        void ReadAllDeleted();
        void ReadACustomer();
        void UpdateACustomer();
        void DeleteACustomer();
        void TakeBackDeletedCustomer();
    }
}