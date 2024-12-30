using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers;

public class CustomerController : ICustomerController
{
    private readonly ICustomerCreaterController _customerCreaterController;
    private readonly ICustomerReadController _customerReadController;
    private readonly ICustomerUpdateController _customerUpdateController;
    private readonly ICustomerDeleteController _customerDeleteController;

    public CustomerController
        (ICustomerCreaterController customerCreaterController,
        ICustomerReadController customerReadController,
        ICustomerUpdateController customerUpdateController,
        ICustomerDeleteController customerDeleteController)
    {
        _customerCreaterController = customerCreaterController;
        _customerReadController = customerReadController;
        _customerUpdateController = customerUpdateController;
        _customerDeleteController = customerDeleteController;
    }

    public void CreateCustomer()
    {
        _customerCreaterController.CreateANewCustomer();
    }

    public void ReadAllCustomers()
    {
        _customerReadController.ShowAllCustomers();
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
        _customerUpdateController.UpdateACustomerInformation();
    }
    public void DeleteACustomer()
    {
        _customerDeleteController.DeleteCustomer();
    }
    public void TakeBackDeletedCustomer()
    {
        _customerUpdateController.GetBackDeletedCustomer();
    }
}