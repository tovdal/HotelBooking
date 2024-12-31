using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder.Interface;
using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder
{
    public class CustomerUpdateRestore : ICustomerUpdateRestore
    {
        private readonly ICustomerUpdate _customerUpdate;
        private readonly ICustomerRead _customerRead;

        public CustomerUpdateRestore(ICustomerUpdate customerUpdate,
            ICustomerRead customerRead)
        {
            _customerUpdate = customerUpdate;
            _customerRead = customerRead;
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
                    (deletedCustomers, "There are no deleted customers. " +
                    "(Press enter to return to menu)");

                if (ListHelper.CheckIfListIsEmpty(deletedCustomers))
                {
                    isRunning = false;
                    return;
                }
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