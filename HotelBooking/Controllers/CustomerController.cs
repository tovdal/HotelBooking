using HotelBooking.Controllers.ControllerCustomer.Interface;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Service.CustomerService;

namespace HotelBooking.Controllers
{
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerCreaterController _customerCreaterController;
        private readonly ICustomerReadController _customerReadController;
        private readonly CustomerRead _customerRead;
        //private readonly CustomerUpdate _guestUpdate;
        //private readonly CustomerDelete _guestDelete;

        public CustomerController(ICustomerCreaterController customerCreaterController, ICustomerReadController customerReadController)
        {
            _customerCreaterController = customerCreaterController;
            _customerReadController = customerReadController;
            //_guestUpdate = guestUpdate;
            //_guestDelete = guestDelete;
        }

        public void CreateCustomer()
        {
            _customerCreaterController.CreateANewCustomer();
        }

        public void ReadAllCustomers()
        {
            _customerReadController.ShowAllCustomers();
        }
        public void ReadAllActive()
        {
            _customerReadController.ShowAllActiveCustomers();
        }
        public void ReadAllInactive()
        {
            _customerReadController.ShowAllInactiveCustomers();
        }

        public void ReadAllDeleted()
        {
            _customerReadController.ShowAllDeletedCustomers();
        }

        public void ReadACustomer()
        {
            _customerReadController.ShowACustomersDetailes();
        }
        public void UpdateACustomer()
        {

        }
        public void DeleteACustomer()
        {

        }
        public void TakeBackDeletedCustomer()
        {

        }
    }
}
