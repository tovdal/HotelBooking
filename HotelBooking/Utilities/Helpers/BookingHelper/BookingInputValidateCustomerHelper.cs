using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Utilities.Validators;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper
{
    public class BookingInputValidateCustomerHelper
    {
        public static int ValidateBookingCustomer(ICustomerRead _customerRead)
        {
            bool customerValid = false;
            int customerId = 0;

            while (!customerValid)
            {
                Console.Clear();

                var registeredCustomers = _customerRead.GetAllActiveCustomers().ToList();
                var customerTable = new Table();
                customerTable.AddColumn("Customer ID");
                customerTable.AddColumn("First Name");
                customerTable.AddColumn("Last Name");

                foreach (var customer in registeredCustomers)
                {
                    customerTable.AddRow(
                        $"{customer.Id}",
                        $"{customer.FirstName}",
                        $"{customer.LastName}");
                }

                if (!registeredCustomers.Any())
                {
                    AnsiConsole.MarkupLine("[bold red]No active customers found...Any key to try again[/]");
                    Console.ReadKey();
                    continue;
                }

                AnsiConsole.Write(customerTable);

                AnsiConsole.MarkupLine("[bold green]Type in customer ID[/]");
                if (ValidatorCustomer.TryGetCustomerId(out customerId))
                {
                    if (_customerRead.CustomerExists(customerId))
                    {
                        customerValid = true;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]No customer with that ID! Please try again.[/]");
                        Console.ReadKey();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Invalid customer ID! Please try again.[/]");
                    Console.ReadKey();
                }
            }

            AnsiConsole.MarkupLine("[bold green]Customer validated![/]");
            Console.ReadKey();

            return customerId;
        }

    }
}