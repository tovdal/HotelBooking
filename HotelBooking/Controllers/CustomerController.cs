using HotelBooking.Service.CustomerService;

namespace HotelBooking.Controllers
{
    public class CustomerController
    {
        //private readonly CustomerCreate _guestCreate;
        private readonly CustomerRead _customerRead;
        //private readonly CustomerUpdate _guestUpdate;
        //private readonly CustomerDelete _guestDelete;

        public CustomerController(CustomerRead customerRead)
        {
            //_guestCreate = guestCreate;
            _customerRead = customerRead;
            //_guestUpdate = guestUpdate;
            //_guestDelete = guestDelete;
        }

        public void CreateANewCustomer()
        {


        }
        public void ShowAllCustomers()
        {
            var customers = _customerRead.GetAllCustomersInDatabase();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
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
                    Console.WriteLine(customer); // richard säger ToString.
                }
            }
        }
        public void ShowAllInactiveCustomers()
        {
            var customers = _customerRead.GetAllInactiveCustomersInDatabase();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        public void ShowAllDeletedCustomers()
        {
            var customers = _customerRead.GetAllDeletedCustomersInDatabase();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
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

            if (customers == null || customers.Count == 0)
            {
                Console.WriteLine($"No Customer with ID number: {customerId}.");
                return;
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}");
                Console.WriteLine($"Name: {customer.FirstName}");
                Console.WriteLine($"Name: {customer.LastName}");
                Console.WriteLine($"IsActive: {customer.IsCustomerStatusActive}");
                Console.WriteLine("-------------------------");
            }
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
