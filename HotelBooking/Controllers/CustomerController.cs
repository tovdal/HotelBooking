using HotelBooking.Service.CustomerService;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Models;
using HotelBooking.Utilities;
using HotelBooking.Utilities.Display.Message;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    public class CustomerController : ICustomerController
    {
        private readonly CustomerCreate _customerCreate;
        private readonly CustomerRead _customerRead;
        //private readonly CustomerUpdate _guestUpdate;
        //private readonly CustomerDelete _guestDelete;

        public CustomerController(CustomerRead customerRead, CustomerCreate customerCreate)
        {
            _customerCreate = customerCreate;
            _customerRead = customerRead;
            //_guestUpdate = guestUpdate;
            //_guestDelete = guestDelete;
        }

        public void CreateANewCustomer()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                Console.WriteLine("1. Create new course");

                string customerFirstName = InputValidatorString.GetValidUserInput
                    ("Enter customer's first name: ");

                string customerLastName = InputValidatorString.GetValidUserInput
                    ("Enter customer's last name: ");

                string customerEmail = InputValidatorString.GetValidUserInput
                    ("Enter customer's email: ");

                string customerPhoneNumber = InputValidatorString.GetValidUserInput
                    ("Enter customer's phone number: ");

                string? customerAdress = InputValidatorString.GetValidUserInput
                    ("Enter customer's address (optional): ");

                var newCustomer = new Customer()
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    Email = customerEmail,
                    PhoneNumber = customerPhoneNumber,
                    Adress = customerAdress,
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                };

                _customerCreate.AddCustomer(newCustomer);

                Console.Clear();
                Console.WriteLine($"Customer '{customerFirstName}', {customerLastName} has been successfully added.");

                Console.WriteLine("Do you want to add another customer? (y/n)");
                string userInput = Console.ReadLine();

                if (userInput?.ToLower() != "y")
                {
                    IsRunning = false;
                }
            }
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
            if (customers == null)
            {
                Console.WriteLine("There is no customers registerd.");
                return;
            }
            else
            {
                Console.WriteLine("List of Customers:");
                // Spector....?
                foreach (var customer in customers)
                {
                    Console.WriteLine($"" +
                    $"Customer ID: {customer.Id}," +
                    $" Name: {customer.FirstName}, " +
                    $"{customer.LastName} " +
                    $"Email: {customer.Email} " +
                    $"Phone number: {customer.PhoneNumber} " +
                    $"Active customer: {customer.IsCustomerStatusActive}" +
                    $"Customer has booking: {customer.Bookings}"); // richard säger ToString.
                }
            }
            ConsoleMessagePrinter.DisplayMessage();
        }
        public void ShowAllInactiveCustomers()
        {
            var customers = _customerRead.GetAllInactiveCustomersInDatabase();
            if (customers == null)
            {
                Console.WriteLine("There is no customers registerd.");
                return;
            }
            else
            {
                if (!customers.Any())
                {
                    Console.WriteLine("List of Customers:");
                    // Spector....?
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"" +
                    $"Customer ID: {customer.Id}," +
                    $" Name: {customer.FirstName}, " +
                    $"{customer.LastName} " +
                    $"Email: {customer.Email} " +
                    $"Phone number: {customer.PhoneNumber} " +
                    $"Address: {customer.Adress} " +
                    $"Active customer: {customer.IsCustomerStatusActive}" +
                    $"Customer has booking: {customer.Bookings}"); // richard säger ToString.
                    }
                }
                else
                {
                    Console.WriteLine("There is no inactive guests");
                }
            }
            ConsoleMessagePrinter.DisplayMessage();
        }
        public void ShowAllDeletedCustomers()
        {
            var customers = _customerRead.GetAllDeletedCustomersInDatabase();
            foreach (var customer in customers)
            {
                Console.WriteLine($"" +
                $"Customer ID: {customer.Id}," +
                $" Name: {customer.FirstName}, " +
                $"{customer.LastName} " +
                $"Email: {customer.Email} " +
                $"Phone number: {customer.PhoneNumber} " +
                $"Address: {customer.Adress} " +
                $"Active customer: {customer.IsCustomerDeleted}"); // richard säger ToString.
            }
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

            var customers = _customerRead.GetCustomerDetailes(customerId);

            if (customers == null || customers.Any())
            {
                Console.WriteLine($"No Customer with ID number: {customerId}.");
                return;
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.Id}," +
                    $" Name: {customer.FirstName}, " +
                    $"{customer.LastName} " +
                    $"Email: {customer.Email} " +
                    $"Phone number: {customer.PhoneNumber} " +
                    $"Address: {customer.Adress} " +
                    $"Active customer: {customer.IsCustomerStatusActive}" +
                    $"Customer has booking: {customer.Bookings}");
                Console.WriteLine("-------------------------");
            }
            ConsoleMessagePrinter.DisplayMessage();
        }
        public void UpdateACustomer()
        {

        }
        public void DeleteACustomer()
        {

        }
        public void TakeBackDeletedCustomer()
        {

        }
    }
}
