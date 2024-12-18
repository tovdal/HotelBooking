using HotelBooking.Models;

namespace HotelBooking.Data.Seeders
{
    public class CustomerSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CustomerSeeding()
        {
            
            var customer = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Chris",
                    LastName = "Doe",
                    Email = "Chris.doe@live.com",
                    PhoneNumber = "123-456-7890",
                    Adress = "123 Main St, Sundsvall",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Jennifer",
                    LastName = "Smith",
                    Email = "jennifer.smith@yahoo.com",
                    PhoneNumber = "987-654-3210",
                    Adress = "456 Elm St, Happaranda",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@outlook.com",
                    PhoneNumber = "555-123-4567",
                    Adress = "789 Oak St, Québec",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob.ross@gmail.com",
                    PhoneNumber = "555-765-4321",
                    Adress = "321 Pine St, Woodsland",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Raphael",
                    LastName = "Brown",
                    Email = "raphael.brown@hotmail.com",
                    PhoneNumber = "555-234-5678",
                    Adress = "654 Sand St, Oasis",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                }
            };
            _dbContext.Customers.AddRange(customer);
            _dbContext.SaveChanges();
        }
    }
}