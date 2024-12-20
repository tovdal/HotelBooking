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
                    PhoneNumber = "0734567890",
                    Adress = "123 Storgatan, Sundsvall",
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Jennifer",
                    LastName = "Larsson",
                    Email = "jennifer.Larsson@yahoo.com",
                    PhoneNumber = "0726543210",
                    Adress = "456 Vintervägen, Happaranda",
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Wilma",
                    LastName = "Johnson",
                    Email = "Wilma.johnson@outlook.com",
                    PhoneNumber = "0701234567",
                    Adress = "789 FrenchSteet, Québec",
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob.ross@gmail.com",
                    PhoneNumber = "0107654321",
                    Adress = "321 Pine St, Woodsland",
                    IsCustomerDeleted = false
                },
                new Customer
                {
                    FirstName = "Raphael",
                    LastName = "Andersson",
                    Email = "raphael.Andersson@hotmail.com",
                    PhoneNumber = "0702345678",
                    Adress = "1 Sand , Oasis",
                    IsCustomerDeleted = false
                }
            };
            dbContext.Customers.AddRange(customer);
            dbContext.SaveChanges();
        }
    }
}