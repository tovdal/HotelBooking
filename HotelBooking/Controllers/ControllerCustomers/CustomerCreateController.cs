using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Helpers;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerCreateController : ICustomerCreaterController
    {
        private readonly CustomerCreate _customerCreate;
        public CustomerCreateController(CustomerCreate customerCreate)
        {
            _customerCreate = customerCreate;
        }
        public void CreateANewCustomer()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                AnsiConsole.MarkupLine("[bold green]1. Create a new customer[/]");

                var newCustomer = CustomerInputHelper.PromptCustomerDetails();

                DisplayHelper.DisplayCustomerDetails(newCustomer);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    _customerCreate.AddCustomer(newCustomer);
                    AnsiConsole.MarkupLine("[bold green]Customer successfully registered![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Registration canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to add another customer?");
                if (!addAnother)
                {
                    IsRunning = false;
                }
            }
        }
    }
}