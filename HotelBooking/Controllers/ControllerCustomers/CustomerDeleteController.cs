using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerDeleteController : ICustomerDeleteController
    {
        private readonly CustomerRead _customerRead;
        private readonly CustomerUpdate _customerUpdate;
        private readonly CustomerDelete _customerDelete;

        public CustomerDeleteController(CustomerRead customerRead,
            CustomerUpdate customerUpdate, CustomerDelete customerDelete)
        {
            _customerRead = customerRead;
            _customerUpdate = customerUpdate;
            _customerDelete = customerDelete;
        }

        public void DeleteCustomer()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                var customers = _customerRead.GetAllActiveCustomers()
                    .ToList();
                DisplayCustomerInformation.PrintCustomersNamesAndID
                    (customers, "There are no customers registered");

                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
                    isRunning = false;
                    continue;
                }

                var customerToDelete = _customerUpdate.ReturnCustomerWithId(customerId);

                if (!ValidatorCustomer.ValidateCustomerForUpdate
                    (customerToDelete, customerId, _customerDelete))
                {
                    continue;
                }

                bool selectedCustomerAsDeleted =
                    AnsiConsole.Confirm($"Do you want to delete customer: " +
                    $"{customerToDelete.FirstName} {customerToDelete.LastName}?");

                Console.Clear();
                if (selectedCustomerAsDeleted)
                {
                    customerToDelete.IsCustomerDeleted = true;
                    _customerUpdate.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm
                    ("Do you want to delete another customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}