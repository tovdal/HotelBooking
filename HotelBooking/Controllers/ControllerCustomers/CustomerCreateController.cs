using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Utilities.Display.DisplayInformation;
using HotelBooking.Utilities.Helpers.CustomerHelper;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomers
{
    public class CustomerCreateController : ICustomerCreaterController
    {
        private readonly ICustomerCreate _customerCreate;
        public CustomerCreateController(ICustomerCreate customerCreate)
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

                DisplayCustomerInformation.DisplayCustomerDetails(newCustomer);

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