using HotelBooking.Controllers.ControllerCustomer.Interface;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display;
using HotelBooking.Utilities.Display.Message;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerCustomer
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
            var customers = _customerRead.GetAllCustomersInDatabase()
                .Include(c => c.Bookings)
                .ThenInclude(b => b.Rooms)
                .ToList();

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
            table.AddColumn("Address");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.Id.ToString(),
                    $"{customer.FirstName} {customer.LastName}",
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Adress ?? "N/A"
                );
                table.AddEmptyRow();

                if (customer.Bookings != null && customer.Bookings.Any())
                {
                    foreach (var booking in customer.Bookings)
                    {
                        table.AddRow("  ", "Booking ID:", booking.Id.ToString(), "Date:", booking.CheckInDate.ToString(), "Total Cost:", booking.TotalCostOfTheBooking.ToString());
                        table.AddEmptyRow();

                        foreach (var room in booking.Rooms)
                        {
                            table.AddRow("  ", "Room ID:", room.Id.ToString());
                        }
                        table.AddEmptyRow();

                        table.AddRow("  ", "Invoice ID:", booking.Invoice?.Id.ToString() ?? "No invoice", "Total Cost:", booking.Invoice?.CostAmount.ToString() ?? "N/A");
                        table.AddEmptyRow();
                    }
                }
                else
                {
                    table.AddRow("  ", "No bookings found.");
                    table.AddEmptyRow();
                }
            }

            AnsiConsole.Write(table);
            ConsoleMessagePrinter.DisplayMessage();


            // Add Pagination can be found in richards powerpoint 
        }

        public void ShowAllActiveCustomers()
        {
            var customers = _customerRead.GetAllActiveCustomerInDatabase();
            DisplayCustomerInformation.PrintCustomersAll(customers, "There are no active customers.");
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllInactiveCustomers()
        {
            var customers = _customerRead.GetAllInactiveCustomersInDatabase();
            DisplayCustomerInformation.PrintCustomersOnly(customers, "There are no inactive customers.");
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllDeletedCustomers()
        {
            var customers = _customerRead.GetAllDeletedCustomersInDatabase();
            DisplayCustomerInformation.PrintCustomersOnly(customers, "There are no deleted customers.");
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowACustomersDetailes()
        {
            Console.WriteLine("Enter the ID of the Customer you want to look at: ");
            var stringCustomerID = Console.ReadLine();

            if (!int.TryParse(stringCustomerID, out int customerId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return;
            }

            var customer = _customerRead.GetCustomerDetailes(customerId);
            DisplayCustomerInformation.PrintCustomersAll(customer, $"No customer found with ID number: {customerId}.");
            ConsoleMessagePrinter.DisplayMessage();
        }
    }
}