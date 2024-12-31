using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService.Interfaces
{
    public interface ICustomerRead
    {
        IQueryable<Customer> GetAllActiveCustomers();
        IQueryable<Customer> GetAllDeletedCustomersInDatabase();
        bool CustomerExists(int customerId);
        IQueryable<Customer> GetCustomerDetailes(int id);
    }
}