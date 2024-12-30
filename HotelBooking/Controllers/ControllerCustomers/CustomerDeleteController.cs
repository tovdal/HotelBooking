using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Data;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly CustomerDelete _customerDelete;

        public CustomerDeleteController(CustomerRead customerRead, CustomerUpdate customerUpdate, CustomerDelete customerDelete, ApplicationDbContext dbContext)
        {
            _customerRead = customerRead;
            _customerUpdate = customerUpdate;
            _dbContext = dbContext;
            _customerDelete = customerDelete;
        }

        public void DeleteCustomer()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var customers = _customerRead.GetAllActiveCustomers().ToList();
                DisplayCustomerInformation.PrintCustomersNamesAndID
                    (customers, "There are no customers registered");

                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
                    return;
                }

                var customerToDelete = _customerUpdate.ReturnCustomerWithId(customerId);

                if (customerToDelete == null)
                {
                    AnsiConsole.MarkupLine($"[bold red]No customer found with ID number: {customerId}[/]");
                    Console.ReadKey();
                    return;
                }

                if (_customerDelete.HasCustomerBooking(customerId))
                {
                    AnsiConsole.MarkupLine("[bold red]The customer has a booking, can't be deleted[/]");
                    Console.ReadKey();
                    return;
                }

                bool selectedCustomerAsDeleted = 
                    AnsiConsole.Confirm($"Do you want to delete customer: " +
                    $"{customerToDelete.FirstName} {customerToDelete.LastName}?");

                Console.Clear();
                if (selectedCustomerAsDeleted)
                {
                    customerToDelete.IsCustomerDeleted = true;
                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("Do you want to delete another customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}
