using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder;
using HotelBooking.Controllers.ControllerCustomers.Interface;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerUpdateController : ICustomerUpdateController
    {
        private readonly CustomerUpdateCustomer _customerUpdateCustomer;
        private readonly CustomerUpdateRestore _customerUpdateRestoreCustomer;

        public CustomerUpdateController(CustomerUpdateCustomer customerUpdateCustomer,
            CustomerUpdateRestore customerUpdateRestore)
        {
            _customerUpdateCustomer = customerUpdateCustomer;
            _customerUpdateRestoreCustomer = customerUpdateRestore;
        }
        public void UpdateACustomerInformation()
        {
            _customerUpdateCustomer.UpdateACustomerInformation();
        }

        public void GetBackDeletedCustomer()
        {
            _customerUpdateRestoreCustomer.GetBackDeletedCustomer();
        }
    }
}