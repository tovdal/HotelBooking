namespace HotelBooking.Service.CustomerService.Interfaces
{
    public interface ICustomerDelete
    {
        bool HasCustomerBooking(int customerId);
    }
}