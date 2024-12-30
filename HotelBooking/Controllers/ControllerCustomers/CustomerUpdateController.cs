using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder;
using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder.Interface;
using HotelBooking.Controllers.ControllerCustomers.Interface;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerUpdateController : ICustomerUpdateController
    {
        private readonly ICustomerUpdateCustomer _customerUpdateCustomer;
        private readonly ICustomerUpdateRestore _customerUpdateRestoreCustomer;

        public CustomerUpdateController(ICustomerUpdateCustomer customerUpdateCustomer,
            ICustomerUpdateRestore customerUpdateRestore)
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