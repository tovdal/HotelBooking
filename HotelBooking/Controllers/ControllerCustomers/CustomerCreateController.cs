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

                string street = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter street: ")
                        .ValidationErrorMessage("[red]Street cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                string city = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter city: ")
                        .ValidationErrorMessage("[red]City cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                string postalCode = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter postal code: ")
                        .ValidationErrorMessage("[red]Postal code cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                string country = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter country: ")
                        .ValidationErrorMessage("[red]Country cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );

                var address = new Address
                {
                    Street = street,
                    City = city,
                    PostalCode = postalCode,
                    Country = country
                };

                var newCustomer = new Customer()
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    Email = customerEmail,
                    PhoneNumber = customerPhoneNumber,
                    Address = address,
                    IsCustomerDeleted = false
                };

                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("First Name", customerFirstName);
                table.AddRow("Last Name", customerLastName);
                table.AddRow("Email", customerEmail);
                table.AddRow("Phone Number", customerPhoneNumber);
                table.AddRow("Street", street);
                table.AddRow("City", city);
                table.AddRow("Postal Code", postalCode);
                table.AddRow("Country", country);
                table.AddRow("Deleted", newCustomer.IsCustomerDeleted ? "Yes" : "No");
                AnsiConsole.Write(table);

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