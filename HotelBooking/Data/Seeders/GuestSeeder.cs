using HotelBooking.Models;

namespace HotelBooking.Data.Seeders
{
    public class GuestSeeder
    {
        private readonly HotelBookingDbContext _dbContext;

        public GuestSeeder(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void GuestSeeding()
        {
            var guests = new List<Guest>
            {
                new Guest
                {
                    FirstName = "Chris",
                    LastName = "Doe",
                    Email = "Chris.doe@live.com",
                    PhoneNumber = "123-456-7890",
                    Adress = "123 Main St, Sundsvall",
                    IsGuestStatusActive = true,
                    IsGuestDeleted = false
                },
                new Guest
                {
                    FirstName = "Jennifer",
                    LastName = "Smith",
                    Email = "jennifer.smith@yahoo.com",
                    PhoneNumber = "987-654-3210",
                    Adress = "456 Elm St, Happaranda",
                    IsGuestStatusActive = true,
                    IsGuestDeleted = false
                },
                new Guest
                {
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@outlook.com",
                    PhoneNumber = "555-123-4567",
                    Adress = "789 Oak St, Québec",
                    IsGuestStatusActive = true,
                    IsGuestDeleted = false
                },
                new Guest
                {
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob.ross@gmail.com",
                    PhoneNumber = "555-765-4321",
                    Adress = "321 Pine St, Woodsland",
                    IsGuestStatusActive = true,
                    IsGuestDeleted = false
                },
                new Guest
                {
                    FirstName = "Raphael",
                    LastName = "Brown",
                    Email = "raphael.brown@hotmail.com",
                    PhoneNumber = "555-234-5678",
                    Adress = "654 Sand St, Oasis",
                    IsGuestStatusActive = true,
                    IsGuestDeleted = false
                }
            };
            _dbContext.Guests.AddRange(guests);
            _dbContext.SaveChanges();
        }
    }
}