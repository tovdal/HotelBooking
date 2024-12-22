﻿using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Data;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.PrintInformation;
using HotelBooking.Utilities.Display.Message;
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

                Console.Clear();

                var customer = _customerRead.GetCustomerDetailes(customerId);
                DisplayCustomerInformation.PrintCustomersOnlyDetailes
                    (customer, $"No customer found with ID number: {customerId}.");

                AnsiConsole.MarkupLine("[bold green]Update the customer[/]");

                string newFirstName = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update customer first name: ")
                        .ValidationErrorMessage("[red]Name cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );
                string newLastName = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update customer last name: ")
                        .ValidationErrorMessage("[red]Name cannot be empty![/]")
                        .Validate(input => !string.IsNullOrWhiteSpace(input))
                );
                string newEmail = AnsiConsole.Prompt(
                        new TextPrompt<string>("Update customer email: ")
                            .ValidationErrorMessage("[red]Please enter a valid email address![/]")
                            .Validate(input => input.Contains("@"))
                    );

                string newPhoneNumber = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update customer phone number: ")
                        .ValidationErrorMessage("[red]Phone number must be numeric![/]")
                        .Validate(input => long.TryParse(input, out _))
                );

                string? newAdress = AnsiConsole.Prompt(
                    new TextPrompt<string>("Update customer address (optional): ")
                        .AllowEmpty()
                );

                Console.Clear();
                var table = new Table();
                table.AddColumn("[bold]Field[/]");
                table.AddColumn("[bold]Value[/]");
                table.AddRow("Customer ID", customerToUpdate.Id.ToString());
                table.AddRow("First Name", newFirstName);
                table.AddRow("Last Name", newLastName);
                table.AddRow("Email", newEmail);
                table.AddRow("Phone Number", newPhoneNumber);
                table.AddRow("Address", string.IsNullOrEmpty(newAdress) ? "N/A" : newAdress);
                AnsiConsole.Write(table);

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    customerToUpdate.FirstName = newFirstName;
                    customerToUpdate.LastName = newLastName;
                    customerToUpdate.Email = newEmail;
                    customerToUpdate.PhoneNumber = newPhoneNumber;
                    customerToUpdate.Adress = newAdress;
                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Customer successfully registered![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Update canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to change another customer?");
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
