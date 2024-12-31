using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;
using HotelBooking.Models;
using HotelBooking.Service.BookingService;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerReadController : ICustomerReadController
    {
        private readonly CustomerRead _customerRead;
        public CustomerReadController(CustomerRead customerRead)
        {
            _customerRead = customerRead;
        }
        public void ShowAllCustomers()
        {
            var customers = _customerRead.GetAllActiveCustomers().ToList();

            DisplayCustomerInformation.PrintCustomerShowAll
                 (customers, "There are no customers registered");

            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllDeletedCustomers()
        {
            var customers = _customerRead.GetAllDeletedCustomersInDatabase();

            DisplayCustomerInformation.PrintCustomersOnlyDetailes
                (customers, "There are no deleted customers.");

            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowACustomersDetailes()
        {
            bool isSearching = true;
            while (isSearching)
            {
                Console.Clear();
                var customers = _customerRead.GetAllActiveCustomers();

                AnsiConsole.MarkupLine($"[green]Show a customer's details[/]");

                DisplayCustomerInformation.PrintCustomersNamesAndID
                    (customers, "There are no customers.");

                if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
                {
                    continue;
                }

                var customer = _customerRead.GetCustomerDetailes(customerId).FirstOrDefault();
                if (customer == null)
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]No customer found with ID number: {customerId}.[/]");
                    Console.ReadKey();
                    continue;
                }

                if (!ValidatorCustomer.IsCustomerDeleted(customer, customerId))
                {
                    isSearching = false;
                    return;
                }

                DisplayCustomerInformation.PrintCustomersAll
                    (new List<Customer> { customer }, 
                    $"No customer found with ID number: {customerId}.");

                ConsoleMessagePrinter.DisplayMessage();
                isSearching = false;
            }
        }
    }
}