using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

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
            var customers = _customerRead.GetAllActiveCustomers();

            AnsiConsole.MarkupLine($"[green]Show a customers details[/]");

            DisplayCustomerInformation.PrintCustomersNamesAndID
                (customers, "There are no customers.");

            if (!ValidatorCustomer.TryGetCustomerId(out int customerId))
            {
                return;
            }

            var customer = _customerRead.GetCustomerDetailes(customerId);

            DisplayCustomerInformation.PrintCustomersAll
                (customer, $"No customer found with ID number: {customerId}.");

            ConsoleMessagePrinter.DisplayMessage();
        }
    }
}