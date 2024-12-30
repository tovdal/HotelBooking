﻿using HotelBooking.Controllers.ControllerCustomers.Interface;
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

            if (customers == null || !customers.Any())
            {
                AnsiConsole.MarkupLine("[red]There are no customers registered.[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Customer ID");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber
                );
                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
            ConsoleMessagePrinter.DisplayMessage();
            // Add Pagination can be found in richards powerpoint 
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

            if (!ValidatorCustomerId.TryGetCustomerId(out int customerId))
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