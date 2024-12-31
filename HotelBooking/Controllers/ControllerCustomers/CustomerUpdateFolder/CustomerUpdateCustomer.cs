using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder.Interface;
using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Helpers.CustomerHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder
{
    public class CustomerUpdateCustomer : ICustomerUpdateCustomer
    {
        private readonly ICustomerUpdate _customerUpdate;
        private readonly ICustomerRead _customerRead;
        private readonly ICustomerDelete _customerDelete;

        public CustomerUpdateCustomer(ICustomerUpdate customerUpdate,
            ICustomerRead customerRead,
            ICustomerDelete customerDelete)
        {
            _customerUpdate = customerUpdate;
            _customerRead = customerRead;
            _customerDelete = customerDelete;
        }
        public void UpdateACustomerInformation()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var customers = _customerRead.GetAllActiveCustomers()
                    .ToList();
                DisplayCustomerInformation.PrintCustomersOnlyDetailes(customers,
                    "There are no customers registered. (Press enter to return to menu)");

                if(ListHelper.CheckIfListIsEmpty(customers))
                {
                    isRunning = false;
                    return;
                }
                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
                    isRunning = false;
                    continue;
                }

                var customerToUpdate = _customerUpdate.ReturnCustomerWithId
                    (customerId);

                if (!ValidatorCustomer.ValidateCustomerForUpdate
                    (customerToUpdate, customerId, _customerDelete))
                {
                    continue;
                }

                var updatedCustomer = CustomerInputHelper.PromptCustomerDetails();

                DisplayCustomerInformation.DisplayCustomerDetails(updatedCustomer);

                bool confirm = AnsiConsole.Confirm
                    ("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    customerToUpdate.FirstName = updatedCustomer.FirstName;
                    customerToUpdate.LastName = updatedCustomer.LastName;
                    customerToUpdate.Email = updatedCustomer.Email;
                    customerToUpdate.PhoneNumber = updatedCustomer.PhoneNumber;
                    customerToUpdate.Address = updatedCustomer.Address;

                    _customerUpdate.SaveChanges();
                    AnsiConsole.MarkupLine
                        ("[bold green]Customer successfully updated![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Update canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm
                    ("\nDo you want to update another customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }
                Console.Clear();
            }
        }
    }
}