using HotelBooking.Models;

namespace HotelBooking.Service.CustomerService.Interfaces
{
    public interface ICustomerUpdate
    {
        Customer ReturnCustomerWithId(int id);
        void SaveChanges();
    }
}