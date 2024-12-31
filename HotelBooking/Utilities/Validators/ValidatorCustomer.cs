using HotelBooking.Models;
using HotelBooking.Service.CustomerService.Interfaces;
using Spectre.Console;

namespace HotelBooking.Utilities.Validators
{
    public class ValidatorCustomer
    {
        public static bool TryGetCustomerId(out int customerId)
        {
            Console.Write("Enter the ID of the Customer: ");
            var stringCustomerID = Console.ReadLine();

            if (!int.TryParse(stringCustomerID, out customerId))
            {
                AnsiConsole.MarkupLine
                    ("[bold red]Please enter a valid number ID[/]");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        public static bool ValidateCustomerForUpdate(Customer customerToUpdate,
               int customerId, ICustomerDelete customerDelete)
        {
            if (customerToUpdate == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No customer found with ID number: {customerId}.[/]");
                Console.ReadKey();
                return false;
            }
            if (customerDelete.HasCustomerBooking(customerId))
            {
                AnsiConsole.MarkupLine
                    ("[bold red]The Customer has a booking, can't be changed[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool ValidateDeletedCustomerForRestore(Customer customerToUpdate,
            int customerId)
        {
            if (customerToUpdate == null || !customerToUpdate.IsCustomerDeleted)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No deleted Customer found with ID number: {customerId}.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public static bool ValidateDeletedCustomers(List<Customer> deletedCustomers)
        {
            if (!deletedCustomers.Any())
            {
                AnsiConsole.MarkupLine("[bold red].[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool IsCustomerDeleted(Customer customer, int customerId)
        {
            if (customer.IsCustomerDeleted)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]Room with ID number: {customerId} is deleted.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}