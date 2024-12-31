using HotelBooking.Models;

namespace HotelBooking.Data.Seeders
{
    public class CustomerSeeder
    {
        public void CustomerSeeding(ApplicationDbContext dbContext)
        {
            var addresses = new List<Address>
                {
                    new Address
                    {
                        Street = "123 Storgatan",
                        City = "Sundsvall",
                        PostalCode = "85230",
                        Country = "Sweden"
                    },
                    new Address
                    {
                        Street = "456 Vintervägen",
                        City = "Happaranda",
                        PostalCode = "95331",
                        Country = "Sweden"
                    },
                    new Address
                    {
                        Street = "789 FrenchSteet",
                        City = "Québec",
                        PostalCode = "G1A 1A1",
                        Country = "Canada"
                    },
                    new Address
                    {
                        Street = "321 Pine St",
                        City = "Woodsland",
                        PostalCode = "12345",
                        Country = "USA"
                    },
                    new Address
                    {
                        Street = "1 Sand",
                        City = "Oasis",
                        PostalCode = "54321",
                        Country = "Desertland"
                    }
                };

            dbContext.Address.AddRange(addresses);
            dbContext.SaveChanges();

            var customers = new List<Customer>
                {
                    new Customer
                    {
                        FirstName = "Chris",
                        LastName = "Bäck",
                        Email = "chris.bäck@live.com",
                        PhoneNumber = "0734567890",
                        Address = addresses[0],
                        IsCustomerDeleted = false
                    },
                    new Customer
                    {
                        FirstName = "Jennifer",
                        LastName = "Larsson",
                        Email = "jennifer.larsson@yahoo.com",
                        PhoneNumber = "0726543210",
                        Address = addresses[1],
                        IsCustomerDeleted = false
                    },
                    new Customer
                    {
                        FirstName = "Wilma",
                        LastName = "Johnson",
                        Email = "wilma.johnson@outlook.com",
                        PhoneNumber = "0701234567",
                        Address = addresses[2],
                        IsCustomerDeleted = false
                    },
                    new Customer
                    {
                        FirstName = "Bob",
                        LastName = "Ross",
                        Email = "bob.ross@gmail.com",
                        PhoneNumber = "0107654321",
                        Address = addresses[3],
                        IsCustomerDeleted = false
                    },
                    new Customer
                    {
                        FirstName = "Raphael",
                        LastName = "Andersson",
                        Email = "raphael.andersson@hotmail.com",
                        PhoneNumber = "0702345678",
                        Address = addresses[4],
                        IsCustomerDeleted = false
                    }
                };

            dbContext.Customers.AddRange(customers);
            dbContext.SaveChanges();
        }
    }
}