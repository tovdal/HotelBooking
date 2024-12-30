using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers.CustomerHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerUpdateController : ICustomerUpdateController
    {
        private readonly CustomerUpdate _customerUpdate;
        private readonly CustomerRead _customerRead;
        private readonly CustomerDelete _customerDelete;

        public CustomerUpdateController(CustomerUpdate customerUpdate,
            CustomerRead customerRead,
            CustomerDelete customerDelete)
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
                var customers = _customerRead.GetAllCustomersAndAddress()
                    .ToList();
                DisplayCustomerInformation.PrintCustomersOnlyDetailes(customers,
                    "There are no customers registered");

                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
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
        public void GetBackDeletedCustomer()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var deletedCustomers = _customerRead.GetAllDeletedCustomersInDatabase()
                .ToList();
                DisplayCustomerInformation.PrintCustomersOnlyDetailes
                    (deletedCustomers, "There are no deleted customers.");

                if (!ValidatorCustomer.ValidateDeletedCustomers(deletedCustomers))
                {
                    isRunning = false;
                    continue;
                }

                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
                    continue;
                }

                var customerToUpdate = _customerUpdate.ReturnCustomerWithId(customerId);
                if (!ValidatorCustomer.ValidateDeletedCustomerForRestore
                    (customerToUpdate, customerId))
                {
                    continue;
                }

                bool restoreCustomer = AnsiConsole.Confirm($"Do you want to " +
                    $"restore deleted customer: {customerToUpdate.FirstName} " +
                    $"{customerToUpdate.LastName}?");
                if (restoreCustomer)
                {
                    customerToUpdate.IsCustomerDeleted = false;
                    _customerUpdate.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Customer successfully " +
                        "restored![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Restore canceled.[/]");
                }

                Console.Clear();
                bool addAnother = AnsiConsole.Confirm("Do you want to restore " +
                    "another deleted customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}