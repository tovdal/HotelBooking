using HotelBooking.Models;

namespace HotelBooking.Data.Seeders
{
    public class CustomerSeeder
    {
        public void CustomerSeeding(ApplicationDbContext dbContext)
        {
            
            var customer = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Chris",
                    LastName = "Bäck",
                    Email = "Chris.Bäck@live.com",
                    PhoneNumber = "073-456-7890",
                    Adress = "123 Storgatan, Sundsvall",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Jennifer",
                    LastName = "Larsson",
                    Email = "jennifer.Larsson@yahoo.com",
                    PhoneNumber = "072-654-3210",
                    Adress = "456 Vintervägen, Happaranda",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Wilma",
                    LastName = "Johnson",
                    Email = "Wilma.johnson@outlook.com",
                    PhoneNumber = "070-123-4567",
                    Adress = "789 FrenchSteet, Québec",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob.ross@gmail.com",
                    PhoneNumber = "010-765-4321",
                    Adress = "321 Pine St, Woodsland",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Raphael",
                    LastName = "Andersson",
                    Email = "raphael.Andersson@hotmail.com",
                    PhoneNumber = "070-234-5678",
                    Adress = "1 Sand , Oasis",
                    IsCustomerStatusActive = true,
                    IsCustomerDeleted = false
                }
            };
            dbContext.Customers.AddRange(customer);
            dbContext.SaveChanges();
        }
    }
}