using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Models;
using HotelBooking.Service.CustomerService;
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

                string customerFirstName = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter customer's first name: ")
                        .ValidationErrorMessage("[red]Name cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                string customerLastName = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter customer's last name: ")
                        .ValidationErrorMessage("[red]Name cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                string customerEmail = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter customer's email: ")
                        .ValidationErrorMessage("[red]Please enter a valid email address![/]")
                        .Validate(input => input.Contains("@"))
                );

                string customerPhoneNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter customer's phone number: ")
                        .ValidationErrorMessage("[red]Phone number must be numeric![/]")
                        .Validate(input => long.TryParse(input, out _))
                );

                string? customerAdress = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter customer's address (optional): ")
                        .AllowEmpty()
                );

                var newCustomer = new Customer()
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    Email = customerEmail,
                    PhoneNumber = customerPhoneNumber,
                    Adress = customerAdress,
                    IsCustomerDeleted = false
                };

                _customerCreate.AddCustomer(newCustomer);

                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("Customer ID", newCustomer.Id.ToString());
                table.AddRow("First Name", customerFirstName);
                table.AddRow("Last Name", customerLastName);
                table.AddRow("Email", customerEmail);
                table.AddRow("Phone Number", customerPhoneNumber);
                table.AddRow("Address", string.IsNullOrEmpty(customerAdress) ? "N/A" : customerAdress);
                table.AddRow("Deleted", newCustomer.IsCustomerDeleted ? "Yes" : "No");
                AnsiConsole.Write(table);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
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