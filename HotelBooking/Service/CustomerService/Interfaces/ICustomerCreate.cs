using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService.Interfaces
{
    public interface ICustomerCreate
    {
        void AddCustomer(Customer newCustomer);
    }
}