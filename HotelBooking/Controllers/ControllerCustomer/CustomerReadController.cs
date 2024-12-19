using HotelBooking.Controllers.ControllerCustomer.Interface;
using HotelBooking.Models;
using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display;
using HotelBooking.Utilities.Display.Message;
using Microsoft.EntityFrameworkCore;

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

            if (customers == null || customers.Count == 0)
            {
                Console.WriteLine("There are no customers registered.");
                return;
            }

            Console.WriteLine("List of Customers:");

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.Id}, " +
                    $"Name: {customer.FirstName} {customer.LastName}, " +
                    $"Email: {customer.Email}");

                if (customer.Bookings != null && customer.Bookings.Any())
                {
                    foreach (var booking in customer.Bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking.Id}, " +
                            $"Date: {booking.CheckInDate}, " +
                            $"Total Cost: {booking.TotalCostOfTheBooking}");

                        if (booking.Rooms.Any())
                        {
                            foreach (var room in booking.Rooms)
                            {
                                Console.WriteLine($"Room ID: {room.Id}");
                            }
                        }
                        Console.WriteLine($"Invoice ID: {booking.Invoice.Id}," +
                            $" Total Cost: {booking.Invoice.CostAmount}");
                    }
                }
                else
                {
                    Console.WriteLine("  No bookings found.");
                }
            }
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllActiveCustomers()
        {
            var customers = _customerRead.GetAllActiveCustomerInDatabase();
            DisplayCustomerInformation.PrintCustomers(customers, "There are no active customers.");
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllInactiveCustomers()
        {
            var customers = _customerRead.GetAllInactiveCustomersInDatabase();
            DisplayCustomerInformation.PrintCustomers(customers, "There are no inactive customers.");
            ConsoleMessagePrinter.DisplayMessage();
        }

        public void ShowAllDeletedCustomers()
        {
            var customers = _customerRead.GetAllDeletedCustomersInDatabase();
            DisplayCustomerInformation.PrintCustomers(customers, "There are no deleted customers.");
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
            DisplayCustomerInformation.PrintCustomers(customer, $"No customer found with ID number: {customerId}.");
            ConsoleMessagePrinter.DisplayMessage();
        }
    }
}