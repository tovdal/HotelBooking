using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Data;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Helpers.CustomerHelper;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerUpdateController : ICustomerUpdateController
    {
        private readonly CustomerUpdate _customerUpdate;
        private readonly CustomerRead _customerRead;
        private readonly ApplicationDbContext _dbContext;

        public CustomerUpdateController(CustomerUpdate customerUpdate, CustomerRead customerRead, ApplicationDbContext dbContext)
        {
            _customerUpdate = customerUpdate;
            _customerRead = customerRead;
            _dbContext = dbContext;

        }
        public void UpdateACustomerInformation()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var customers = _customerRead.GetAllActiveCustomers()
                    .ToList();
                DisplayCustomerInformation.PrintCustomersNamesAndID(customers,
                    "There are no customers registered");

                if (!ValidatorCustomerId.TryGetCustomerId(out int customerId))
                {
                    return;
                }
                var customerToUpdate = _customerUpdate.ReturnCustomerWithId(customerId);

                if (customerToUpdate == null)
                {
                    Console.WriteLine($"No customer found with ID number: {customerId}.");
                    return;
                }

                var updatedCustomer = CustomerInputHelper.PromptCustomerDetails();

                DisplayHelper.DisplayCustomerDetails(updatedCustomer);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    customerToUpdate.FirstName = updatedCustomer.FirstName;
                    customerToUpdate.LastName = updatedCustomer.LastName;
                    customerToUpdate.Email = updatedCustomer.Email;
                    customerToUpdate.PhoneNumber = updatedCustomer.PhoneNumber;
                    customerToUpdate.Address = updatedCustomer.Address;

                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Customer successfully updated![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Update canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to update another customer?");
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
                var customers = _customerRead.GetAllDeletedCustomersInDatabase()
                    .ToList();
                DisplayCustomerInformation.PrintCustomersOnlyDetailes
                    (customers, "There are no deleted customers.");

                var isDeleted = _customerRead.GetCustomersIsDeleted();

                if (!isDeleted)
                {
                    ConsoleMessagePrinter.DisplayMessage();
                    isRunning = false;
                    return;
                }

                if (!ValidatorCustomerId.TryGetCustomerId(out int customerId))
                {
                    return;
                }

                var customerToUpdate = _customerUpdate.ReturnCustomerWithId(customerId);

                if (customerToUpdate == null || !customerToUpdate.IsCustomerDeleted)
                {
                    Console.WriteLine($"No deleted customer found with ID number: {customerId}.");
                    Console.ReadKey();
                    continue;
                }

                bool deleteCustomer = AnsiConsole.Confirm
                    ($"Do you want to take back delete customer: {customerToUpdate.FirstName} " +
                    $"{customerToUpdate.LastName}?");

                if (deleteCustomer)
                {
                    customerToUpdate.IsCustomerDeleted = false;
                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Customer successfully un-deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Retake canceled.[/]");
                }

                Console.Clear();
                bool addAnother = AnsiConsole.Confirm("Do you want to restore another deleted customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }

            }
        }
    }
}
